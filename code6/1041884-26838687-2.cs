    public class Member : Person
    {
        public Member(decimal id, string fName, string lName, ContactInfo contactInfo)
            : base(fName, lName, contactInfo)
        {
            Id = id;
            CurrentMember = "Y";
            TotalDue = 0;
            IsMember = "Y";
            Password = "Default";
        }
        public decimal Id { get; set; }
        public string CurrentMember { get; set; }
        public decimal? TotalDue { get; set; }
        public string IsMember { get; set; }
        public string Password { get; set; }
    }
