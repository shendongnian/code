    public class Member : Person
    {
        public Member(string fName, string lName, ContactInfo contactInfo)
            : base(fName, lName, contactInfo)
        {
            Id = 0;
            CurrentMember = "Y";
            TotalDue = 0;
            IsMember = "Y";
            Password = "Default";
            Managers = new HashSet<Manager>();
            Providers = new HashSet<Provider>();
            Transactionlists = new HashSet<Transactionlist>();
        }
        public decimal Id { get; set; }
        public string CurrentMember { get; set; }
        public decimal? TotalDue { get; set; }
        public string IsMember { get; set; }
        public string Password { get; set; }
        public ICollection<Manager> Managers { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public ICollection<Transactionlist> Transactionlists { get; set; }
    }
