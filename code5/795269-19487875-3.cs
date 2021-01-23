    public class Customer
    {
        public int CustomerId { get; set; }
        public string MembershipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
    public class Company
     {
         public string MembershipId { get; set; }
         public string Name {get; set;}
     }
    public class CustomersBankAccount
     {
       public string Name {get; set;}
       public int CustomerId { get; set; }
     }
