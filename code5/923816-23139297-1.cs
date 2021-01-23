    static string GetStringData(string vehID)
    {
        StringBuilder builder = new StringBuilder();
        string cmd1 = "SELECT Column1 FROM Veh_checkup WHERE Veh_ID = @VehID";
	    using (OleDbConnection con = new OleDbConnection("YourConnectionString"))
	    using (OleDbCommand cmd = new OleDbCommand(cmd1, con))
	    {
		    con.Open();
            cmd.Parameters.AddWithValue("@VehID", vehID);
		    using (OleDbDataReader reader = cmd.ExecuteReader())
		    {
			    while (reader.Read())
			    {
                    builder.Append(" " + reader.GetString(0));
			    }
		    }
	    }
        return builder.ToString();
    }
