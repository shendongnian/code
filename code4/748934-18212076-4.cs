    using (SqlConnection c = new SqlConnection(
    	youconnectionstring))
        {
    	c.Open();
    	/
    	using (SqlDataAdapter a = new SqlDataAdapter(sql, c))
    	{
    	    
    	    DataTable t = new DataTable();
    	    a.Fill(t);
            if(t.Rows.Count > 0)
             {
                 string text  = t.Rows[0]["yourColumn"].ToString();
             }    
    	}
        }
