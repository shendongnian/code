    public SqlDataReader executeQuerys(string query01, string paramName, string value)
    {
    	using (SqlConnection con = new SqlConnection(DBConnect.makeConnection()))
    	{
    		try
    		{
    			con.Open();
    			com = new SqlCommand(query01, con);
    			com.Parameters.AddWithValue(paramName, value);
    			return com.ExecuteReader(CommandBehavior.CloseConnection);
    		}
    
    		catch(SqlException ex)
    		{
    			//Handle the exceptio
    			//no need to dispose connection manually
                //using statement will take care of that
    		}
    	}
    }
