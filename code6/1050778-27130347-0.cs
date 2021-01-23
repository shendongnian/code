    int var = 0;
    string conn = " ... ";
    using (OleDbConnection connection = new OleDbConnection(conn))
    using (OleDbCommand cmd = new OleDbCommand("SELECT ID, DATA_1, DATA_2 from Database WHERE ID = ( SELECT MAX (ID) @Value FROM Database);", connection))
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
    				using (OleDbConnection connection2 = new OleDbConnection(conn))
    				using (OleDbCommand cmd2 = new OleDbCommand(@"SELECT ID, DATA_1, DATA_2 from Database WHERE ID = ( SELECT MAX (ID) @Value FROM Database);", connection2))
    				{
    					cmd.Parameters.AddWithValue("@Value", var);
    					connexion2.Open();
    					using (OleDbDataReader reader2 = cmd2.ExecuteReader())
    					{
    						reader2.Read();
    						var++;
    					}
    				}
    			}
    		}
    		else
    		{
    			Label5.Text = "Line Empty";
    		}
    	}
    }
