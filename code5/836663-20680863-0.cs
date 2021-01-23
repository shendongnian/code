    using (SqlConnection Conn = new SqlConnection(connectionStringMigplus))
    {
    	try
    	{
    		Conn.Open();
    		ret=true;
    	}
    	catch (SqlException)
    	{
    		ret = false;
    	}
    }
