    class Project
    {
        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
    }
    class Address
    {
        // Your address properties here...
    }
