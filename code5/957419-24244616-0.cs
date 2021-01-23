    var efConnectionString = ConfigurationManager.ConnectionStrings["MainDbContext"].ConnectionString;
    using (var conn = new EntityConnection(efConnectionString))
    {
    	conn.Open();
    
    	using (var context = new MainDbContext(conn, false))
    	{
    	}
    }
