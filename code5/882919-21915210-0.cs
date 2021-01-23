    using (OracleConnection connection = new OracleConnection("Connection String"))
    {	
    	using (OracleCommand cmd = new OracleCommand("select * from tbl", connection))
    	{
    		connection.Open();
    		//do database stuff
    	}
    }
