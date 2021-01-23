    public class Customer
    {
        public Customer()
        {
            Address = new Address();
        }
 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
 
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
    }
 
    public  class  CustomerContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Customer>()
                    .HasRequired(x => x.Address)
                    .WithRequiredPrincipal();
             base.OnModelCreating(modelBuilder);
        }
    }
