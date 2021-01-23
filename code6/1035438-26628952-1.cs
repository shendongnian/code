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
	
    ProductClass[] productClasses = new ProductClass[] {  
            new ProductClass("Beverages"),   
            new ProductClass("Condiments"),   
            new ProductClass("Vegetables"),   
            new ProductClass("Dairy Products"),   
            new ProductClass("Seafood")
    };  
      
    List<Product> products = new List<Product>();
    products.Add(new Product("Seafood", "crab sticks"));
    products.Add(new Product("Seafood", "lobster"));
   	products.Add(new Product("Vegetables", "cucumber"));
   	products.Add(new Product("Seafood", "oysters"));
   	products.Add(new Product("Condiments", "pepper"));
   	products.Add(new Product("Condiments", "salt"));
      
    var query = 
        from pc in productClasses 
        join p in products on pc.ProductType equals p.Category 
        select new { Category = pc, p.ProductName };
