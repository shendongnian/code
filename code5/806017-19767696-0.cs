    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public List<Product> Products = new List<Product>();
    }
    
    public static class CategoryManager
    {
        public List<Category> Categories = new List<Category>();
    }
    
    public Product test = new Product
    {
        Id = 1
    };
    
    public Category add = new Category
    {
        Id = 1
    };
    
    public void Init()
    {
        add.Products.Add(test);
        CategoryManager.Categories.Add(add);
    }
    
    public Product GetByID(Category cat, string val)
    {
       return cat.Where(x => x.Id == val).ToArray()[0];
    }
    
    public Category GetCat(Product pro)
    {
        foreach (var cat in CategoryManager.Categories)
        {
           if (cat == pro) return cat;
        }
        return null;
    }
