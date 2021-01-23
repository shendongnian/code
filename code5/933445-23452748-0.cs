	using (SqlDataReader reader = command.ExecuteReader())
	{
		StringBuilder sb = new StringBuilder();
		if (reader.HasRows)
		{
			if (sb.Length > 0) sb.Append("___");
			while (reader.Read())
			{
				for (int i = 0; i < reader.FieldCount; i++)
					if (reader.GetValue(i) != DBNull.Value)
						sb.AppendFormat("{0}-", Convert.ToString(reader.GetValue(i)));
			}
		}
	}
