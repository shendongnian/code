    using (var scope = new TransactionScope(TransactionScopeOption.Required)) 
    { 
    	using (var conn = new SqlConnection("...")) 
    	{ 
    		conn.Open(); 
    
    		var sqlCommand = new SqlCommand(); 
    		sqlCommand.Connection = conn; 
    		sqlCommand.CommandText = 
    			@"UPDATE Blogs SET Rating = 5" + 
    				" WHERE Name LIKE '%Entity Framework%'"; 
    		sqlCommand.ExecuteNonQuery(); 
    
    		using (var context = 
    			new BloggingContext(conn, contextOwnsConnection: false)) 
    		{ 
    			var query = context.Posts.Where(p => p.Blog.Rating > 5); 
    			foreach (var post in query) 
    			{ 
    				post.Title += "[Cool Blog]"; 
    			} 
    			context.SaveChanges(); 
    		} 
    	} 
    
    	scope.Complete(); 
    } 
