    using(SqlConnection connection = new SqlConnection(_connectionString))
	{
		String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";
		using(SqlCommand command = new SqlCommand(query, connection))
		{
			command.Parameters.AddWithValue("@id", "abc");
			command.Parameters.AddWithValue("@username", "abc");
			command.Parameters.AddWithValue("@password", "abc");
			command.Parameters.AddWithValue("@email", "abc");
			connection.Open();
			int result = command.ExecuteNonQuery();
      
            // Check Error
            if(result < 0)
                Console.WriteLine("Error inserting data into Database!");
		}
	}
