    List<string> Columnnames = new List<string>();
    
    // Code that populates Columnnames here
    
    cmd = new SqlCommand("Select " + string.Join(",", Columnnames) + " from test");
