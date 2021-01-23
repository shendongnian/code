    static Func<DbConnection, DbProviderFactory> GetFactoryDelegate;
    
    private static void Main() {
        Console.WriteLine(GetFactory(new SqlConnection()).CreateDataAdapter());
    }
    private static DbProviderFactory GetFactory(DbConnection connection) {
        if (GetFactoryDelegate == null) {
            var frameworkGetFactoryMethod = typeof (DbProviderFactories).GetMethod(
                "GetFactory", BindingFlags.Static | BindingFlags.Public,
                null, new[] { typeof (DbConnection) }, null);
    
            if (frameworkGetFactoryMethod != null) {
                GetFactoryDelegate = (Func<DbConnection, DbProviderFactory>)
                    Delegate.CreateDelegate(
                        typeof(Func<DbConnection, DbProviderFactory>),
                        frameworkGetFactoryMethod);
            }
            else { GetFactoryDelegate = GetFactoryThroughWorkaround; }
        }
        return GetFactoryDelegate(connection);
    }
    private static DbProviderFactory GetFactoryThroughWorkaround(
        DbConnection connection) {
    
        if (connection is SqlConnection)
            return SqlClientFactory.Instance;
        // ... Remaining cases
        throw new NotSupportedException();
    }
