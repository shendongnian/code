    string sql = "SELECT email FROM Table WHERE Field = @Parameter";
    string variable;
    using (var connection = new SqlConnection("Your Connection String"))
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.AddWithValue("@Parameter", someValue);
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            //Check the reader has data:
			if (reader.Read())
			{
				variable = reader.GetString(reader.GetOrdinal("Column"));
			}
			// If you need to use all rows returned use a loop:
            while (reader.Read())
            {
                // Do something
            }
        }
    }
