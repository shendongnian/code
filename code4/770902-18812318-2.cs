    public class Xyz
    {
        // Your code
        public int AddressId { get; set; }
        public virtual Address MyAddress { get; set; }
    }
    // Your Address class
    public class Address
    {
        public int ID;
    }
