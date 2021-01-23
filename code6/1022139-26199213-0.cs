    using (var connection = new OleDbConnection("..."))
    using (var command = new OleDbCommand("...", connection))
    {
        connection.Open();
    
        using (var reader = command.ExecuteReader())
        {
            // ...
        }
    }
