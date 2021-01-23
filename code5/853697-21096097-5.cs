    public static class Db
    {
        static readonly Func<DbConnection, DbProviderFactory> getDbProviderFactory = 
            (Func<DbConnection, DbProviderFactory>)Delegate.CreateDelegate(typeof(Func<DbConnection, DbProviderFactory>), typeof(DbConnection).GetProperty("DbProviderFactory", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(true));
        static readonly Func<DbCommandBuilder, string, string> getParameterName =
            (Func<DbCommandBuilder, string, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, string, string>), typeof(DbCommandBuilder).GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(string) }, null));
        public static DbProviderFactory GetProviderFactory(this DbConnection connection)
        {
            return getDbProviderFactory(connection);
        }
        public static string GetParameterName(this DbConnection connection, string paramName)
        {
            DbCommandBuilder builder = GetProviderFactory(connection).CreateCommandBuilder();
            return getParameterName(builder, paramName);
        }
    }
