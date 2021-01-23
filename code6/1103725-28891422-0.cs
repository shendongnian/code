    public bool CheckTheEmail(string email)
    {
    	using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["insQuoteConnectionString"].ConnectionString))
    	{
    		con.Open();
    
    		using (SqlCommand cmd = new SqlCommand("select EmailAddress from AspNetUsers", con))
    		using (SqlDataReader reader = cmd.ExecuteReader())
    		{
    			if (reader == default(SqlDataReader))
    			{
    				return false;
    			}
    			
    			while (reader.Read())
    			{
    				//do something
    
    			    if (reader[0] != null && reader[0].ToString() == email)
    				{
    					Console.WriteLine("ok");
    					return true;
    				}
    			}
    		}
    	}
    	
    	return false;
    }
