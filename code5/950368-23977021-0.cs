    using (var adapter = new SqlDataAdapter("SELECT statement here", "source connection string here"))
    using (var destinationConnection = new SqlConnection("destination connection string here"))
    using (var insertCommand = new SqlCommand("INSERT statement here", destinationConnection))
    {
        // Add parameters to insertCommand here.
    
        adapter.InsertCommand = insertCommand;
    
        // Leave the RowState of all DataRows as Added so they are ready to be inserted.
        adapter.AcceptChangesDuringFill = false;
    
        var table = new DataTable();
    
        // Retrieve data from source and save to destination.
        adapter.Fill(table);
        adapter.Update(table);
    }
