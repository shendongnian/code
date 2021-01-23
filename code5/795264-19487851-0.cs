    using System.ComponentModel.DataAnnotations;
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public Guid MembershipID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
