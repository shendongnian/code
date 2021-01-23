    public class ContactInfo
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
