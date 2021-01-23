    public class Address
    {
        public int ID { get; set; }
    
        public string City { get; set; }
    
        public string Street { get; set; }
    
        public string Postcode { get; set; }
    
        public virtual User User { get; set;}
    }
