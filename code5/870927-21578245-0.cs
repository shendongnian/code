    using (var adapter = new SqlDataAdapter("SELECT ID FROM MyTable", "connection string here"))
    {
        var table = new DataTable();
    
        adapter.Fill(table);
    
        var ids = table.AsEnumerable().Select(row => row.Field<int>("ID")).ToArray();
        var minId = ids.Min();
        var maxId = ids.Max();
        var missingIds = Enumerable.Range(minId, maxId - minId + 1).Except(ids);
    }
