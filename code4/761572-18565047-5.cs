    public class Customer {
      public int ID { get; set; }
      public string Name { get; set; }
      public int GroupID { get; set; }
      public string Prefix {get;set;}
      public string FullName {
        get { return Prefix + Name;}
      }            
    }
    //then to display the fullname, just get the customer.FullName; 
    //You can also try adding some override of ToString() to your class
    var groupedCustomerList = CustomerList
                             .GroupBy(u => {u.Prefix="User", return u.GroupID;} , (key,g)=>g.ToList())
                             .ToList();
