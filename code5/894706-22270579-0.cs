    public class Product
    {
      public int Id { get; set; }
      public string ProductName { get; set; }
      public double Size { get; set; }
    }
    		 
    private List<Product> AddProducts()
    {
      List<Product> ProductList = new List<Product>();
    
      var p = new Product();
      p.Id = 1;
      p.ProductName = "Product1";
      p.Size = 25;
      ProductList.Add(p);
    
    
      var p2 = new Product();
      p2.Id = 2;
      p2.ProductName = "Product2";
      p2.Size = 25;
      ProductList.Add(p2);
    
      return ProductList;           
    }
    
    public void Index(string productname = "", int? size = null)
    {
      var oProdList = from p in AddProducts() select p;
    
      if (size != null)
      {
      	oProdList = oProdList.Where(p => p.ProductName.ToUpper() == productname.ToUpper());
      }
      else
      {
        oProdList = oProdList.Where(p => p.ProductName.ToUpper() == productname.ToUpper() || p.Size == size);
      }
    
      ViewBag.ProductList = oProdList;
      return View();
    }
