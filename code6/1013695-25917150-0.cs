    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0"));
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
            SetProviderServices("System.Data.SqlServerCe.4.0", SqlCeProviderServices.Instance);
        }
    }
