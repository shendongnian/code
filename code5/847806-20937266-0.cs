    public IEnumerable<T> Query<T>(string query, object param) 
    {
        var connectionString = ConfigurationManager.ConnectionStrings["SomeString"].ConnectionString;
    
        using(var connection = new SqlConnection(connectionString)) 
        {
            return connection.Query<T>(query, param);
        }
    }
