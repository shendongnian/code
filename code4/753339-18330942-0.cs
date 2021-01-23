    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    
        public virtual Address Address { get; set; }
    }
    public class Address : Entity
    {
        public string AddressName { get; set; }
    
        public virtual User User { get; set; }
    }
