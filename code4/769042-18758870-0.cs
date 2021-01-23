     DataSet dataset = new DataSet();
     using (SqlConnection conn = new SqlConnection(connString))
     {
         SqlDataAdapter adapter = new SqlDataAdapter();                
         adapter.SelectCommand = new SqlCommand("select * from tableA", conn);
         conn.Open(); 
         adapter.Fill(dataset);
    	 conn.Close(); 
    	 foreach (DataRow row in dataset.Tables[0]) // Loop over the rows.
    	{
    		// perform your operation
    	}
     }  
