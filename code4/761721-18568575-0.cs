	using (SqlConnection con = new SqlConnection(_conStr))
    {
        con.Open();
        using(SqlCommand cmd = new SqlCommand(procedureName, con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cmd.Parameters.AddWithValue("@tvp", SqlDbType.Structured);
            param.Value = dt;
			using (var reader = cmd.ExecuteReader())
			{
				int result = 0;
				
				while (reader.Read())
				{
					// Do something with the reader, then increment result by 1 to get total rows affected
					result++;
				}
			}
            return result;
        }
    }
