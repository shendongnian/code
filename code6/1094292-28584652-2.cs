    // Microsoft.ApplicationServer.Caching.Configuration.ConfigurationBase
    ...
    if (provider.Equals("System.Data.SqlClient"))
    {
    	ConfigurationBase.ValidateSqlConnectionString(connectionString);
    }
    ...
    internal static void ValidateSqlConnectionString(string connectionString)
    {
    	SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
    	if (!sqlConnectionStringBuilder.IntegratedSecurity || !string.IsNullOrEmpty(sqlConnectionStringBuilder.UserID) || !string.IsNullOrEmpty(sqlConnectionStringBuilder.Password))
    	{
    		int errorCode = 17032;
    		string sqlAuthenticationNotSupported = Resources.SqlAuthenticationNotSupported;
    		throw new DataCacheException("DistributedCache.ConfigurationCommands", errorCode, sqlAuthenticationNotSupported);
    	}
    }
