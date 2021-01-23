    public class AppDataContext : DbContext, IDbContext
    {
        private readonly IDatabase database;
        public AppDataContext()
            : base("Name=CONNECTIONSTRING")
        {
            base.Configuration.ProxyCreationEnabled = false;
            this.database = new DatabaseWrapper(base.Database);
        }
        ...
        
        // Added to be able to execute stored procedures
        IDatabase Database { get { return database; } }
    }
