    public bool IsValidSqlScript(string sqlScript)
    {
    	bool status;
    	
    	try
    	{
    		using (SQLConnection)
    		{
    			using (SQLTransaction)
    			{
    				SQLConnection.Execute("SET PARSEONLY ON " + sqlScript);                    
    			}
    		}
    		status = true;
    	}
    	catch(Exception e)
    	{
    		status = false;
    	)
    	
    	return status;
    }
