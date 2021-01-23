    using (IDbConnection conn = new MySql.Data.MySqlClient.MySqlConnection(...))
    {
    	using (IDbCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select ...", conn))
    	{
    		conn.Open();
    		var reader = cmd.ExecuteReader()';
    		// process reader, etc
    	}
    }
