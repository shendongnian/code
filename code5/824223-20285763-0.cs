    class Customer
    {
      public List<Products> Products 
      { 
         get { return CustomerProductRelationship.CustomerProducts[this];}
         set 
         {
            CustomerProductRelationship.AddPair(value, this);
         }
    }
    
    class Product
    {
      public List<Products> Products 
      { 
         get { return CustomerProductRelationship.ProductCustomers[this];}
         set 
         {
            CustomerProductRelationship.AddPair(this, value);
         }
      }
    }
    
    static class CustomerProductRelationship
    {
      public static Dictionary<Customer, List<Product>> CustomerProducts;
      public static Dictionary<Product, List<Customer> ProductCustomers;
      public static AddPair(Product product, Customer customer)
      {
           if (!CustomerProducts.Contains(customer))
              CustomerProducts.Add(customer, new List<Product>);
    
           CustomerProducts[customer].Add(product);
    
           if (!ProductCustomers.Contains(product))
              ProductCustomers.Add(product, new List<Customers>);
    
           CustomerProducts[product].Add(customer);
       }
    }
