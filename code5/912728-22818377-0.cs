    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int BillingAddressId { get; set; }
        public int DeliveryAddressId { get; set; }
            
        public Address BillingAddress { get; set; }
        public Address DeliveryAddress { get; set; }
    }
     
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
     
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
