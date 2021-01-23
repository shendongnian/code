    public class Customer
    {
        public Customer
        {
    
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Addressid { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
    
    
    public class Address
    {
        public Address
        {
    
        }
    
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Country { get; set; }
        public int CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }              
    }
