using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    
    public class EditModel : PageModel
    {
     
        public readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "Fields cannot be same!!!");
            }
         
            if (ModelState.IsValid)
            {
                 _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
