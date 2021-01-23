    public static List<ImageClass> GetImages()
    {
       var objList = new List<ImageClass>();
       string connectionString = "yourConnection";
    	
    	using (SqlConnection con = new SqlConnection(connectionString))
    	{
    	    con.Open();
    	  
    	    using (var command = new SqlCommand("Select top(1) Image_path from Images", con))
    	    using (var reader = command.ExecuteReader())
    	    {
    		    while (reader.Read())
    		    {
    		         objList.Add(new ImageClass()
                                       {
                                          Src = reader["Image_path"].ToString()
                                       });
                     objList.Add(new ImageClass()
                                       {
                                          Src = reader["Image_path"].ToString()
                                       });
    		    } 
    	    }
                
    	}
          return objList ;
    }
