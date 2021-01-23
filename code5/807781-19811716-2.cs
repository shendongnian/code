    public class Category
    {
      IEnumerable<Category> Children {get;set;}
      IEnumerable<Product> Products {get;set;}
    }
    
    public IEnumerable<Category> GetCategory(int? parent)
    {
      var result = new List<Category>();
      foreach (var cat in categories.Where(p => p.parentId = parent)
      {
         var generatedCategory = new Category();
         generatedCategory.Children = GetCategory(cat.id);
         generatedCategory.Products = products.Where(p => p.CategoryId = cat.CategoryId);
         result.Add(generatedCategory);
      }
      return result;
    }
