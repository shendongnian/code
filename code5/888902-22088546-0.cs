    // Create a collection of parameters with the values that the procedure is expecting in your SQL client.
    SqlParameter[] parameters = { new SqlParameter("@id", qid), 
    new SqlParameter("@otherValue", value) };
    
    // Add teh parameters to the command.
    sqlc.Parameters.AddRange(parameters)
