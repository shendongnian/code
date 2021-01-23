    static void Main(string[] args) {
      // You should declare and fill in the products list
      // where you'll be looking for the product
      List<Product> products = new List<Product>() {
        //TODO: Replace it with the actual products
        new Product() {Name = "Product A"},
        new Product() {Name = "Product B"},
        new Product() {Name = "Product C"}
      };
    
      // Ask user for the product name
      Console.WriteLine("Enter the name of the product");
    
      string pname = Console.ReadLine();
    
      // The product user's looking for
      Product res = SearchRestaurantsByName(pname, products);
    
      //TODO: change this for required response to user
      if (res != null) 
        Console.WriteLine("The product is found");  
      else 
        Console.WriteLine("The product is not found");  
    }
