    public class Contact
    {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
    
         public Address PersonalAddress { get; set; }
         public Address BusinessAddress { get; set; }
    }
    
    [ComplexType]
    public class Address{
        public string Street{ get; set; }
        public string City{ get; set; }
        public string PostalCode{ get; set; }
    }
