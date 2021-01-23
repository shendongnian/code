    public CacheDependency GetOracleCacheDependency(string query)
    {
        string connStr = DatabaseConfig.ConnectionStringForViewer;
        OracleConnection conn = new OracleConnection(connStr)
        conn.Open();
        OracleCommand cmd = new OracleCommand(query, conn)
        OracleCacheDependency dependency = new OracleCacheDependency(cmd);
        //This registers dependency to database.
        cmd.ExcuteReader();
        return dependency;
    }
