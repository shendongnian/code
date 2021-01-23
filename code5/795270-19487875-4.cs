      public class Customer
    {
        public int CustomerId { get; set; }
        [Remote("CheckMembershipIdActionMethod", "CorrespondingController")]
        public string MembershipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
