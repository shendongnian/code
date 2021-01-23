    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES(@id,@username,@password, @email)";
        using(SqlCommand command = new SqlCommand(query, db.Connection))
        {
            command.Parameters.AddWithValue("@id","abc");
            command.Parameters.AddWithValue("@username","abc");
            command.Parameters.AddWithValue("@password","abc");
            command.Parameters.AddWithValue("@email","abc");
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
