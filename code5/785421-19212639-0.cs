    public class main_menu
    {
      List<Customer> customers = new List<Customer>(); // empty collection of Customer's
      public void new_customer(string name, string nickname, int age)
      {
        customers.Add( new Customer { name, nickname, age } );
      }
    } 
