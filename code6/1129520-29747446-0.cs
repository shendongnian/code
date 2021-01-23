    public class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
    
    public class RootObject
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string StartDate { get; set; } // Keeped as string for simplicity
        public Address Address { get; set; }
    }
