    public class Product
    {
      //other product properties
    
      //field for the customers list
      private List<Customer> customers = new List<Customer>();
    
      //read-only property for outside access
      public IEnumerable<Customer> Customers 
      {
        get { return customers; }
      }
      
      //internal method that will only be called by the customer class
      internal void AddCustomer(Customer customer)
      {
        customers.Add(customer);
      }
      
      //internal method that will only be called by the customer class
      internal void RemoveCustomer(Customer customer)
      {
        customers.Remove(customer);
      }
    }
