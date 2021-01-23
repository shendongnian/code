    String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username, @password, @email)";
    using(SqlConnection connection = new SqlConnection(connectionString))
    using(SqlCommand command = new SqlCommand(query, connection))
    {
        //a shorter syntax to adding parameters
        command.Parameters.Add("@id", SqlDbType.NChar).Value = "abc";
    
        command.Parameters.Add("@username", SqlDbType.NChar).Value = "abc";
        //a longer syntax for adding parameters
        command.Parameters.Add("@password", SqlDbType.NChar).Value = "abc";
        command.Parameters.Add("@email", SqlDbType.NChar).Value = "abc";
    
        //make sure you open and close(after executing) the connection
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
