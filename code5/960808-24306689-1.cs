    public class Customer
    {
       public int CustId {get; set;}
       public string FirstName {get; set;}
       public string LastName {get; set;}
       [JsonIgnore]
       public bool isLocked {get; set;}
       public Customer() {}
    
    }
