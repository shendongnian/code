        using(SqlConnection conn = new SqlConnection("myConnectionString"))
        {
        	using(SqlCommand cmd = new SqlCommand("myStoredProcedure", conn))
        	{
        		cmd.CommandType = CommandType.StoredProcedure;
        		cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
        		try
        		{
        			conn.Open();
        			cmd.ExecuteNonQuery();
        			// -1 if null
        			int id = 0;
        			if (!int.TryParse(cmd.Parameters["@id"].value, out id))
        				id = -1;
        		}
        		catch
        		{
        			throw;
        		}
        		
        	}
        }
