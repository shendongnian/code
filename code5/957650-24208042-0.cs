    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
    	conn.Open();
    
    	using (var cmd = conn.CreateCommand())
    	{
    		string cmdText = "SELECT name FROM sys.tables"
    
    
    		cmd.CommandText = cmdText;
    
    		cmd.ExecuteNonQuery();
    	}
    }
