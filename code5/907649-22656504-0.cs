        var arr = new List<string>();
        var connectionString= "YOUR CONNECTION";
        using (SqlConnection con = new SqlConnection(connectionString))
    	{
    	    
    	    con.Open();
    	    using (SqlCommand command = new SqlCommand("SELECT CL_UnitNumber FROM COM_ConnectionLogRfmDevices", con))
    	    using (SqlDataReader reader = command.ExecuteReader())
    	    {
    		   while (reader.Read())
    		   {
    		        arr.Add(reader["CL_UnitNumber"] != DBNull.Value
                                                ? reader["CL_UnitNumber"].ToString()
                                                : "");
    		   }
    	    }
            conn.Dispose();
    	}
        return arr.ToArray();
