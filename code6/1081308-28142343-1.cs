    public interface IDbContext : IDisposable
    {
        ...
    
        // Added to be able to execute stored procedures
        IDatabase Database { get; }
    }
