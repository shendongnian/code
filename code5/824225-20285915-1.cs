    public class Customer
    {
      //other customer properties
    
      //field for the product list
      private List<Product> products = new List<Product>();
    
      //read-only property for outside access
      public IEnumerable<Product> Products
      {
        get { return products; }
      }
    
      //public method, open to the world
      public void BuyProduct(Product product)
      {
        products.Add(product);
        product.AddCustomer(this);
      }
      
      //public method, open to the world
      public void RemoveProduct(Product product)
      {
        products.Remove(product);
        product.RemoveCustomer(this);
      }        
    }
