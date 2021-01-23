    public class Address
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public int UserID { get; set; } // Set this property
        public User User { get; set; }
    }
