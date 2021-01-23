	try
	{
		using (var connection = new SqlConnection(connString))
		using (var command = new SqlCommand(sql, connection))
		{
			command.Parameters.Add("@Verb", SqlDbType.VarChar, 50).Value = verb;
			connection.Open();
			using (var reader = command.ExecuteReader())
			if (reader.Read())
			{
				v.BaseTense = Convert.ToString(reader["BaseForm"]);
				v.PastTense = Convert.ToString(reader["PastForm"]);
				v.PastParticiple = Convert.ToString(reader["PastPartForm"]);
			}
		}
	}
	catch (SqlException e)
	{
		//Log the exception or do something else meaningful
		throw;
	}
	catch (Exception e)
	{
		//Log the exception or do something else meaningful
		throw;
	}
