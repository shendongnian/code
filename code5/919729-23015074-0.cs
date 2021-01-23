    public class EntityConnectionStringHelper
        {
            public static string Build()
            {
                string serverName = "******";
                string databaseName = "****";
                string password = "****";
                string userid = "*****";
                string meta = "********";
                return EntityConnectionStringHelper.Build(serverName, databaseName, userid, password, meta);
            }
            public static string Build(string serverName, string databaseName, string userName, string password, string metaData)
            {
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                return EntityConnectionStringHelper.Build(providerName, serverName, databaseName, userName, password, metaData);
            }
            public static string Build(string providerName, string serverName, string databaseName, string userName, string password, string metaData)
            {
                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
    
                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.UserID = userName;
                sqlBuilder.Password = password;
    
                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();
    
                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
    
                //Set the provider name.
                entityBuilder.Provider = providerName;
    
                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;
    
                // Set the Metadata location.
                entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", metaData);
    
                return entityBuilder.ToString();
            }
        }
