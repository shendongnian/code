    public class Product
    {
       public Int32 ProductID {get; set;}
       public String ProductName {get; set;}
       //add more as needed
    }
    public List<KeyValuePair<string, string>> selectSpecificColumn()
    {
         IEnumerable<Product> productTab = from p in context.Products select new Product({ProductID  =p.ProductID, ProductName = p.ProductName});
         return productTab;
    }
