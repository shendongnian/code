    var cmd = db.Database.Connection.CreateCommand(); 
    cmd.CommandText = "some command here"; 
    try 
    { 
         
        db.Database.Connection.Open();   
        var reader = cmd.ExecuteReader(); 
        var books = ((IObjectContextAdapter)db) 
            .ObjectContext 
            .Translate<Book>(reader, "Books", MergeOption.AppendOnly);    
 
        // Move to second result set and read authors
        reader.NextResult(); 
        var authors = ((IObjectContextAdapter)db) 
            .ObjectContext 
            .Translate<Author>(reader, "Authors", MergeOption.AppendOnly); 
    } 
    finally 
    { 
        db.Database.Connection.Close(); 
    } 
