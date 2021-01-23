    public DataTable GetData(SqlConnection Cn)
    {
    	try
    	{
    		DataTable dt = null;
    		using (var cmd = new SqlCommand())
    		{
    			cmd.Connection = Cn;
    			cmd.CommandText = "select * from Table";
    			using (var sda = new SqlDataAdapter(cmd))
    			{
    				dt  = new DataTable();
    				sda.Fill(dt);
    			}
    		}
    		return contNames;
    	}
    	catch (Exception err)
    	{
    		return null;
    	}
    }            
