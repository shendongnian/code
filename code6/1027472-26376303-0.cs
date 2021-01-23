    using(OleDbConnection con = new OleDbConnection(conString))
    using(OleDbCommand cmd = con.CreateCommand())
    {
        // Set your CommandText property.
        // Define and add your parameter values.
        // Open your OleDbConnection.
        // Execute your query with ExecuteNonQuery.
    }
