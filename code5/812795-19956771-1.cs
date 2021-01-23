    String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username, @password, @email)";
    SqlConnection connection = new SqlConnection(connectionString)
    SqlCommand command = new SqlCommand(query, connection);
    
    command.Parameters.Add("@id", SqlDbType.NChar);
    command.Parameters["@id"].Value = "abc";
    
    command.Parameters.Add("@username", SqlDbType.NChar);
    command.Parameters["@username"].Value = "abc";
    command.Parameters.Add("@password", SqlDbType.NChar);
    command.Parameters["@password"].Value = "abc";
    command.Parameters.Add("@email", SqlDbType.NChar);
    command.Parameters["@email"].Value = "abc";
    
    connection.Open();
    command.ExecuteNonQuery();
