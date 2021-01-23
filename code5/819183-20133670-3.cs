	using (SqlConnection connection = new SqlConnection(connectionString))
	{
		// Create the Command and Parameter objects.
		SqlCommand command = new SqlCommand("insert into", connection);
		command.Parameters.AddWithValue("@TagName", "some data...");
		// open connection to the database
		connection.Open();
		SqlDataReader reader = command.ExecuteNonQuery();
	}
