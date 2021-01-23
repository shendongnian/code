    protected static bool TestaIntegracaoErpMigplus()
    {
    	bool ret = true;    
           
    	try
    	{
            string connectionStringMigplus = WebConfigurationManager.ConnectionStrings["ConnectionStringMigplus"].ConnectionString; 
    		using (SqlConnection Conn = new SqlConnection(connectionStringMigplus))
    		{
    			Conn.Open();
    		}
    	}
    	catch (Exception)
    	{
    		ret = false;
    	}
        return ret;
    }
