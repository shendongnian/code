    public class Customer
    {
        public Customer()
        {
            BasicDetails = new BasicDetails();
            AddressDetails = new AddressDetails();
            ContactDetails = new ContactDetails();
        }
    
        public BasicDetails BasicDetails { get; set; }
        public AddressDetails AddressDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
