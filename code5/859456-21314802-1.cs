        public enum DatabaseTypes
        {
            SQL,
            SQL_CE
        }
    public static class DatabaseProvider
    {
        private const string SQL_Provider = "System.Data.SqlClient";
        private const string SQL_CE_Provider = "System.Data.SqlServerCe.3.5";
        public static string GetDatabaseProvider(DatabaseTypes dbType)
        {
            switch (dbType)
            {
                case DatabaseTypes.SQL_CE:
                    return SQL_CE_Provider;
                case DatabaseTypes.SQL:
                default:
                    return SQL_Provider;
            }
        }
    }
