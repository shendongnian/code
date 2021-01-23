	using (var connection = new SqlConnection("ConnectionString"))
	using (var cmd = new new SqlCommand("SP_getName", connection))
	{
		cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = "bob101";
		connection.Open();
		using (var reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				// Do something 
			}
		}
	}
