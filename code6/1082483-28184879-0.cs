    [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true)]
    public static SqlString GetConfig(SqlString WhichOne)
    {
        return ConfigurationManager.ConnectionStrings[WhichOne.Value].ToString();
    }
