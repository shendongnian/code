            // Use DataAdapter to fill DataTable
            DataTable t = new DataTable();
             // 1
    	    // Open connection
    	    using (SqlConnection c = new SqlConnection("Connection string here"))
    	    {
    		  c.Open();
    		  // 2
    		  // Create new DataAdapter
    		  using (SqlDataAdapter a = new SqlDataAdapter("Query Here", c))
    		     {
    		       // 3
    		       // Fill DataTable with data
    		       a.Fill(t);
    
                 }
    	     }
