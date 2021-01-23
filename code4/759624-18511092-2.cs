	using (var connection = new SqlConnection(yourConnectionString))
	using (var command = new SqlCommand("yourStoredProcedure"))
	{
		connection.Open();
		using (var reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				// do something with first result set;
			}
			if (reader.NextResult())
			{
				while (reader.Read())
				{
					// do something with second result set;
				}
			}
			else
			{
				return;
			}
			if (reader.NextResult())
			{
				while (reader.Read())
				{
					// do something with third result set;
				}
			}
			else
			{
				return;
			}
		}
	}
