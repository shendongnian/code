    public void insert(string sql,Dictionary<stirng,object> parameters){
    	using (SqlConnection myConn = new SqlConnection(this.SQLConnectString))
    	using (SqlCommand var_command = new SqlCommand(var_SQLCommand, myConn))
    	{
    		myConn.Open();
    		try
    		{
    			foreach(string name in parameters.Keys){
    				var_Command.Parameters.AddWithValue(name, parameters[name] );
    			}		
    			var_command.ExecuteNonQuery();
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show("An error occurred: " + ex.Message + " using SQL Query: " + var_SQLCommand, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		}
    		finally
    		{
    			myConn.Close();
    		}
    	}
    }
