      public sealed class SomeConfiguration : DbMigrationsConfiguration<SomeDbContext>
        {
            public Configuration()
            {
                //Creates a new instance of DbConnectionInfo based on a connection string.
                TargetDatabase = new DbConnectionInfo(
     connectionString:"The connection string to use for the connection",
     providerInvariantName:"The name of the provider to use for the connection. Use 'System.Data.SqlClient' for SQL Server.");
            }
        }
