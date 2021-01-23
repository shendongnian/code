    // 1. Create the output parameter
    var p = new SqlParameter("RecordCount", 0) { Direction = ParameterDirection.Output };
    // 2. Make the SQL call
    using (var con = new SqlConnection(connString))
    using (var cmd = con.CreateCommand())
    {
        cmd.Parameters.Add(p);
    
        using (var reader = cmd.ExecuteReader())
        {
            // Retrieve reader values from query
        }
    }
    // 3. Retrieve the value of the output parameter
    var recordCount = (long)p;
