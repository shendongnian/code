    public class MyContext : DbContext
    { 
        public DbSet<Customer> Customers { get; set; }
        public IAsyncDbSet<Customer> CustomersAsync { get { return new DbSetAdapter<Customer>(Customers); } }
    }
