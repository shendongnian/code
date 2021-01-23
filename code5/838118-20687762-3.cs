    public static class Database
    {
        private static readonly Func<DbCommandBuilder, int, string> getParameterName = CreateDelegate("GetParameterName");
        private static readonly Func<DbCommandBuilder, int, string> getParameterPlaceholder = CreateDelegate("GetParameterPlaceholder");
        
        private static Func<DbCommandBuilder, int, string> CreateDelegate(string methodName)
        {
            MethodInfo method = typeof(DbCommandBuilder).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(Int32) }, null);
            return (Func<DbCommandBuilder, int, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), method);
        }
        
        private static string GetDefaultProviderName()
        {
            ...
        }
        
        private static string GetDefaultConnectionString()
        {
            ...
        }
        
        public static DbProviderFactory GetProviderFactory()
        {
            string providerName = GetDefaultProviderName();
            return DbProviderFactories.GetFactory(providerName);
        }
        
        private static DbConnection GetDBConnection(DbProviderFactory factory)
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = GetDefaultConnectionString();
            return connection;
        }
        
        public static DbConnection GetDBConnection()
        {
            DbProviderFactory factory = GetProviderFactory();
            return GetDBConnection(factory);
        }
        
        private static void ProcessParameters(
            DbProviderFactory factory, 
            DbCommand command, 
            string query, 
            object[] queryParameters)
        {
            if (queryParameters == null && queryParameters.Length == 0)
            {
                command.CommandText = query;
            }
            else
            {
                IFormatProvider formatProvider = CultureInfo.InvariantCulture;
                DbCommandBuilder commandBuilder = factory.CreateCommandBuilder();
                StringBuilder queryText = new StringBuilder(query);
                
                for (int index = 0; index < queryParameters.Length; index++)
                {
                    string name = getParameterName(commandBuilder, index);
                    string placeholder = getParameterPlaceholder(commandBuilder, index);
                    string i = index.ToString("D", formatProvider);
                    
                    command.Parameters.AddWithValue(name, queryParameters[index]);
                    queryText = queryText.Replace("{" + i + "}", placeholder);
                }
                
                command.CommandText = queryText.ToString();
            }
        }
        
        public static DataView GetDataView(string query, params object[] queryParameters)
        {
            DbProviderFactory factory = GetProviderFactory();
            
            using (DbConnection connection = GetDBConnection(factory))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                ProcessParameters(factory, command, query, queryParameters);
                
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;
                
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table.DefaultView;
            }
        }
    }
