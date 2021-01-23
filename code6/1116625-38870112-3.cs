    [DbConfigurationType(typeof(CodeConfig))] // point to the class that inherit from DbConfiguration
    public class ApplicationDbContext : DbContext
    {
        [...]
    }
    
    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
