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
    
    public ActionResult Index(string productname = "", string size = "")
    {
      var oProdList = from p in AddProducts() select p;
    
      if (!string.IsNullOrWhiteSpace(productname) && !string.IsNullOrWhiteSpace(size))
      {
         oProdList = oProdList.Where(p => p.ProductName.ToUpper().Trim().Contains(productname.ToUpper().Trim()) && p.Size.ToString().Contains(size.Trim()));
      }
      else
      {
        oProdList = oProdList.Where(p => !string.IsNullOrWhiteSpace(productname) ? p.ProductName.ToUpper().Trim().Contains(productname.ToUpper().Trim()) : p.ProductName.ToUpper().Trim() == productname.ToUpper().Trim() || !string.IsNullOrWhiteSpace(size) ? p.Size.ToString().Contains(size.Trim()) : p.Size.ToString() == size.Trim());
      }
    
      ViewBag.ProductList = oProdList;
      return View();
    }
