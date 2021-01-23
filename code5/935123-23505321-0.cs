    public partial class Address
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    
        public virtual User User { get; set; }
    }
