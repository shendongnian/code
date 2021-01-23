    public interface IDataContext : IDisposable 
    { 
    }
    
    public interface IContextA : IDataContext
    {
       public DbSet<User> Users { get; set; } 
    }
    
    public interface IContextB : IDataContext
    {
       public DbSet<Bank> Banks { get; set; } 
    }
    
    public abstract class DataContext : DbContext, IDataContext 
    {
    }
    
    public class ContextA : DataContext, IContextA
    {
    }
    
    public class ContextB : DataContext, IContextB
    {
    }
