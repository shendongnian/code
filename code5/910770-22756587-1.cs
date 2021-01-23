    public static class DB
    {
        private static readonly string connectionString   = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        /// <summary>
        /// Use when returning data from multiple rows
        /// </summary>
        /// <param name="sql">query</param>
        /// <param name="parameters">declared parameters</param>
        /// <returns>datatable of db rows</returns>
        public static DataTable GetDataTable(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection  = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;
                        
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                if (parameter != null)
                                    command.Parameters.Add(parameter);
                            }
                        }
                        using (DbDataAdapter adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
