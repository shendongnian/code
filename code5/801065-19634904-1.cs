    public class Context : DbContext
    {
        public DbSet<Customer> Customers{get;set;}
        public DbSet<CustomerGroup> Groups{get;set;}
    }
