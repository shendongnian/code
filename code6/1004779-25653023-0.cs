    public class ExistingDatabaseContext : DbContext
    {
        public ExistingDatabaseContext()
            : base("ExistingDatabaseConnectionStringName")
        {
            Database.SetInitializer<ExistingDatabaseContext>(null);
        }
        // DbSets here for your "code-first" classes that represent existing database tables
    }
