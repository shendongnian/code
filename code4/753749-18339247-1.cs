    public void DoWork()
    {
        // Build Query Use @Name Parameters instead of direct values to prevent SQL Injection
        StringBuilder sql = new StringBuilder();
        sql.Append("UPDATE UserLogin");
        sql.Append("SET Name = @UpdatedName");
        sql.Append("WHERE Name = @Name);
        
        // Create parameters with the value you want to pass to SQL
        SqlParameter name = new SqlParameter("@Name", "whatEverOldNameWas");
        SqlParameter updatedName = new SqlParameter("@UpdatedName", txtUserName.Text);
        
        Update(sql.ToString(), new [] { name, updatedName });
    }
    
    private static readonly string connectionString   = "Your connection string"
    private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
    public static int Update(string sql, SqlParameter[] parameters)
    {
        try
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection  = connection;
                    command.CommandText = sql;
    
                    foreach (var parameter in parameters)
                    {
                        if (parameter != null)
                            command.Parameters.Add(parameter);
                    }
    
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
