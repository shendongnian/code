    using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    	    connection.Open();	    
    	    using (SqlCommand command = new SqlCommand(
    		"SELECT COUNT(NoEmpl) FROM DTool Where NoEmpl= @NoEmpl", connection))
    	    {
    		//
    		// Add new SqlParameter to the command.
    		//
    		command.Parameters.Add(new SqlParameter("@NoEmpl", searchTerm ));
    		//
    		// Read in the SELECT results.
    		//
    		SqlDataReader reader = command.ExecuteReader();
    		//read here
    	    }
    	}
