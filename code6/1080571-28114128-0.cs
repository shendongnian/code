    static private IDbConnection GetConnection(string dbType)
    {
        if (dbType.Equals("Oracle"))
        {
            OdbcConnection conn = new OdbcConnection
            conn.ConnectionString = here my connection string
            return conn;
        }
        if (dbType.Equals("Ads"))
        {
            AdsConnection conn = new AdsConnection
            conn.ConnectionString = here my connection string
            return conn;
        }
        return null;
    }
