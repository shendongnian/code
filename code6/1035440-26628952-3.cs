    class Product
    {
        
        public Product(string cat, string name)
    	{
    	    Category = cat;
    		ProductName = name;
    	}
    	
    	public string Category { get; set;}
    	public string ProductName { get;set;}
    }
    
    
    class ProductClass
    {
        public ProductClass (string type)
    	{
    		ProductType = type;
    	}	
    	
    	public string ProductType { get;set;}
    }
        
    ProductClass[] productClasses = new ProductClass[]{  
        new ProductClass("Beverages"),   
        new ProductClass("Condiments"),   
        new ProductClass("Vegetables"),   
        new ProductClass("Dairy Products"),   
        new ProductClass("Seafood") };  
      
    List<Product> products = new List<Product>();
    products.Add(new Product("Seafood", "crab sticks"));
    products.Add(new Product("Seafood", "lobster"));
    products.Add(new Product("Vegetables", "cucumber"));
    products.Add(new Product("Seafood", "oysters"));
    products.Add(new Product("Condiments", "pepper"));
    products.Add(new Product("Condiments", "salt"));
      
    var query =
        from pc in productClasses
        join product in products on pc.ProductType equals product.Category into gj
        select new { ProductCategory= pc.ProductType, Products = gj, Count = gj.Count() };
