    string conn = " ... ";
    using (OleDbConnection connexion = new OleDbConnection(conn))
    using (OleDbCommand cmd = new OleDbCommand("SELECT ID, DATA_1, DATA_2 from Database WHERE ID = ( SELECT MAX (ID) FROM Database WHERE DATA_1 IS NOT NULL AND DATA_2 IS NOT NULL);", connexion))
    {
    	connexion.Open();
    	using (OleDbDataReader reader = cmd.ExecuteReader())
    	{
    		if (reader.HasRows)
    		{
    			while (reader.Read())
    			{
    				Label5.Text  = reader["DATA_1"].ToString();
    			}
    		}
    		else
    		{
    			Label5.Text = "Line Empty";
    		}
    	}
    }
