    List<string> unitNumbers = new List<string>();
    using (SqlConnection con = new SqlConnection(_ConnectionString))
    {
	    con.Open();
	    using (SqlCommand command = new SqlCommand("SELECT CL_UnitNumber FROM COM_ConnectionLogRfmDevices", con))
	    {
	        SqlDataReader reader = command.ExecuteReader();
	        while (reader.Read())
	        {
		        unitNumbers.Add(reader.GetInt32(0)); // Or maybe reader.GetString(0)
	        }
	    }
    }
