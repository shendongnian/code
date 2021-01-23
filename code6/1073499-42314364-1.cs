    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
    
            SetSqlGenerator("System.Data.SqlClient", new FixedSqlServerMigrationSqlGenerator ());
        }
        ...
    }
