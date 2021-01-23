    public class MigrateDatabaseToLatestVersionWithConnectionString<TContext, TMigrationsConfiguration> : IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _config;
        public MigrateDatabaseToLatestVersionWithConnectionString()
        {
            _config = new TMigrationsConfiguration();
        }
        public MigrateDatabaseToLatestVersionWithConnectionString(string connectionString)
        {
            // Set the TargetDatabase for migrations to use the supplied connection string
            _config = new TMigrationsConfiguration { 
                TargetDatabase = new DbConnectionInfo(connectionString, 
                                                      "System.Data.SqlClient")
            };
        }
        public void InitializeDatabase(TContext context)
        {
            // Update the migrator with the config containing the right connection string
            DbMigrator dbMigrator = new DbMigrator(_config);
            dbMigrator.Update();
        }
    }
