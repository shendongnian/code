    using(OleDbConnection connection = new OleDbConnection(conString))
    using(OleDbCommand command = con.CreateCommand())
    {
        // Set your CommandText property.
        // Define and add your parameter values.
        // Open your OleDbConnection.
        // Execute your query.
    }
