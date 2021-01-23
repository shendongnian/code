    public class Category
    {
      List<Category> Children {get;set;}
      List<Product> Products {get;set;}
    }
    
    public IEnumerable<Category> GetCategory(int? parent)
    {
      var result = new List<Category>();
      foreach (var cat in categories.Where(p => p.parentId = parent)
      {
         var generatedCategory = new Category();
         generatedCategory.Children = GetCategory(cat.id).ToList();
         generatedCategory.Products = products.Where(p => p.CategoryId = cat.CategoryId).ToList();
         result.Add(generatedCategory);
      }
      return result;
    }
