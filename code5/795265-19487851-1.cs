    using System.ComponentModel.DataAnnotations;
    public class Customer
    {
        
        public Guid CustomerID { get; set; }
        [Key]
        public int MembershipID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
