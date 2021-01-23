    public interface IMyDbContext
    {
        ICollection<Customer> Customers { get; }
    }
    
    public class MyDbContext : IMyContext
    {
        ICollection<Customer> IMyContext.Customers { get { return Customers; } }
    
        public DbSet<Customer> Customers { get; set; }
    }
