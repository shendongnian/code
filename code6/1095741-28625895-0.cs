    public class User
    {
     public string FirstName { get; set; }
     public string LastName{ get; set; }
     public int Age{ get; set; }
     public DateTime DOB{ get; set; }
    }
    
    public class Employee : User
    {
    }
    
    public class Customer : User
    {
    }
