    public interface IMyDbContext
    {
        ICollection<Customer> Customers { get; }
    }
    
    public class MyDbContext : IMyContext
    {
        ICollection<Customer> IMyContext.Customers { get { return (ICollection<Customer>)Customers; } }
    
        public DbSet<Customer> Customers { get; set; }
    }
