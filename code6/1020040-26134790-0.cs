    class Product
    {
       public int Id;
       public string Name;  
    }
    class Category : Product
    {
       public bool IsActive;
    }
    var products = Product.Union(Category.Cast<Product>());
