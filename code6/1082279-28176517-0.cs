    public void RunQuery(string query, params SqlParameter[] parameters)
    {
        using(var connection = new SqlConnection(_connectionString)
        using(var command = new SqlQuery(query, connection)
        {
            connection.Open();
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }
    
    }
