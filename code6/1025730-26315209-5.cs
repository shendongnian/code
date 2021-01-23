    public SqlDataReader executeQuerys(string query01, string paramName, string value)
    {
    	SqlConnection con = null;
    	SqlCommand com = null;
    	try
    	{
    		con = new SqlConnection(DBConnect.makeConnection());
    		con.Open();
    		com = new SqlCommand(query01, con);
    		com.Parameters.AddWithValue(paramName, value);
    		com.Dispose();
    		con.Close();
    	}
    	catch
    	{
    		com.Dispose();
    		con.Close();
    		throw;
    	}
       return com.ExecuteReader(CommandBehavior.CloseConnection);
    }
