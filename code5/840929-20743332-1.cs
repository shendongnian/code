	using (SqlCommand command = new SqlCommand("*SELECT QUERY HERE*", connection))
	{
	//
	// Invoke ExecuteReader method.
	//
	SqlDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
			TextBox2.Text = reader.GetString(0);
		}
	}
