    using (SqlConnection c = new SqlConnection(youconnectionstring))
    {
    	c.Open();
    	/
    	using (SqlDataAdapter a = new SqlDataAdapter(sql, c))
    	{
    	    
    	    DataTable t = new DataTable();
    	    a.Fill(t);    
    	}
    }
