    ...
    if (count == 1) {
      ...
      DateTime dtn = DateTime.Now;    
      string query = 
        @"insert into Time (
            TimeIn) 
          values (
            @TimeIn)"; // <- query parameter instead of query text modification
    
      using (var query = new SqlCommand(query, con)) {
        // bind query parameter with its actual value 
        query.Parameters.AddWithValue("@TimeIn", dtn);
        // Just execute query, no reader
        query.ExecuteNonQuery();
      }
    
      ...
