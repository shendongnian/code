    public class AppUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PhoneNumbers CellNo { get; set; }
        public PhoneNumbers WorkNo { get; set; }
        public PhoneNumbers HomeNo { get; set; }
        public Address OfficeAddress { get; set; }
        public AppUser()
        {
            CellNo = new PhoneNumbers();
            WorkNo = new PhoneNumbers();
            HomeNo = new PhoneNumbers();
            OfficeAddress = new Address();
        }
    }
