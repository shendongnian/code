    [DbConfigurationType(typeof(CodeConfig))] // point to the class that inherit from DbConfiguration
    public class ApplicationDbContext : DbContext
    {
        [...]
    }
    
    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetDefaultConnectionFactory(new MySql.Data.Entity.MySqlConnectionFactory());
            SetProviderServices("MySql.Data.MySqlClient",
                        new MySql.Data.MySqlClient.MySqlProviderServices());
        }
    }
