    public static class Database
    {
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
        
        private static void ProcessParameters(DbCommand command, string query, object[] queryParameters)
        {
            if (queryParameters == null && queryParameters.Length == 0)
            {
                command.CommandText = query;
            }
            else
            {
                IFormatProvider formatProvider = CultureInfo.InvariantCulture;
                StringBuilder queryText = new StringBuilder(query);
                
                for (int index = 0; index < queryParameters.Length; index++)
                {
                    string i = index.ToString("D", formatProvider);
                    string name = "@P" + i;
                    
                    command.Parameters.AddWithValue(name, queryParameters[index]);
                    queryText = queryText.Replace("{" + i + "}", name);
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
                ProcessParameters(command, query, queryParameters);
                
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;
                
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table.DefaultView;
            }
        }
    }
