    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            var providerInstance = SqlProviderServices.Instance;
            SqlProviderServices.TruncateDecimalsToScale = false;
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class DbContext1 : DbContext
    {
    
    }
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class DbContext2 : DbContext
    {
    
    }
