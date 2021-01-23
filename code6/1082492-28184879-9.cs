    [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true)]
    public static SqlString GetConfig(SqlString WhichOne)
    {
        ConfigurationManager.RefreshSection("connectionStrings");
        return ConfigurationManager.ConnectionStrings[WhichOne.Value].ToString();
    }
