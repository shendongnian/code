    public class Person
    {
        public Person()
        {
            Managers = new HashSet<Manager>();
            Providers = new HashSet<Provider>();
            Transactionlists = new HashSet<Transactionlist>();
        }
        public Person(string fName, string lName, ContactInfo contactInfo)
            :this()
        {
            FirstName = fName;
            LastName = lName;
            ContactInfo = contactInfo;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<Manager> Managers { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public ICollection<Transactionlist> Transactionlists { get; set; }
    }
