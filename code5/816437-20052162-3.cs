    const string Query = "SELECT ConnectionString FROM Connection WHERE Id = @Id";
    
    public string GetConnectionString(int id)
    {
    
        using(var connection = GetConnection())
        using(var command = new SqlCommand(Query, connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
        
            using(var reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    return Convert.ToString(reader["ConnectionString"]);
                }
            }
        }
    }
    var connectionString = GetConnectionString(1);
    using(var connection = new SqlConnection(connectionString))
    {
        //logic
    }
