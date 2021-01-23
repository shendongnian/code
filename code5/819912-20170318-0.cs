    using(SqlConnection connection = new SqlConnection("connection_string"))
    {
        using(SqlCommand command = new SqlCommand())
        {
    
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = [some timeout value]; 
            command.CommandText = "Update SomeTable Set Value = 1";
    
            connection.Open();
    
            command.ExecuteNonQuery();
        }
    }
