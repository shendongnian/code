    private static T ExecuteQuery<T>(ContextObject contextObject, string query)
    {
    	T result;
    	using (SqlConnection con = con = new SqlConnection(contextObject.ConnectionString))
    	{
    		try
    		{
    			con.Open();
    			using (SqlCommand cmd = cmd = new SqlCommand(query, con))
    			{
    				result = (T)cmd.ExecuteScalar();
    			}
    		}
    		catch
    		{
    			result = null;
    		}
    		finally
    		{
    			con.Close();
    		}
    		
    	}	
    	returnr result;  
    }
