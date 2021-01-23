    public class Product : IAddProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductCatagoryId { get; set; }
    
        public virtual void Add(Product p)
        {
           //Save to db
        };
    }
    public class DryFruits : Product
    {
        public decimal WeightInGrams { get; set; }
        public decimal RatePerGram { get; set; }
    
        public override void Add(Product p)
        {
          //Save to db
        }
    }
    
    public interface IAddProduct
    {
       void Add(Product product)
    }
    
    Public class SomeClass
    {
      Product product = new DryFruits()
       {
         ProductName = "Nut";
         WeightInGrams = 0.01; 
       }
         private IAddProduct _saveIt;
        _saveIt.Add(product) 
    }
    
    Public class SomeOtherClass
    {
      Product product = new Product()
       {
         ProductName = "Orange";
       }
     private IAddProduct _saveIt;
     _saveIt.Add(product) 
    }
