    public class Customer {
      public int ID { get; set; }
      public string Name { get; set; }
      public int GroupID { get; set; }
      public Customer CloneWithNamePrepend(string prepend){
        return new Customer(){
              ID = this.ID,
              Name = prepend + this.Name,
              GroupID = this.GroupID
         };
      }
    }    
    //Then
    var groupedCustomerList = CustomerList
                             .GroupBy(u => u.GroupID, u=>u.CloneWithNamePrepend("User"), (key,g)=>g.ToList())
                             .ToList();
