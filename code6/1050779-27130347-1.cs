    int var = 0;
    string conn = " ... ";
    using (OleDbConnection connexion = new OleDbConnection(conn))
    using (OleDbCommand cmd = new OleDbCommand("SELECT ID, DATA_1, DATA_2 from Database WHERE ID = ( SELECT MAX (ID) @Value FROM Database);", connexion))
    {
    	cmd.Parameters.AddWithValue("@Value", var);
    	connexion.Open();
    	using (OleDbDataReader reader = cmd.ExecuteReader())
    	{
    		if (reader.HasRows)
    		{
    			reader.Read();
    		}
    
    		if (!reader.HasRows)
    		{
    			while (!reader.HasRows)
    			{
    				using (OleDbConnection connexion2 = new OleDbConnection(conn))
    				using (OleDbCommand cmd2 = new OleDbCommand(@"SELECT ID, DATA_1, DATA_2 from Database WHERE ID = ( SELECT MAX (ID) @Value FROM Database);", connexion2))
    				{
    					cmd.Parameters.AddWithValue("@Value", var);
    					connexion2.Open();
    					using (OleDbDataReader reader2 = cmd2.ExecuteReader())
    					{
    						while (reader2.Read())
    						{
    							reader2.Read();
    							var++;
    						}
    					}
    				}
    			}
    		}
    		else
    		{
    			//Label5.Text = "Line Empty";
    		}
    	}
    }
