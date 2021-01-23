    var valuesNeeded = new[]{ "1000", "1234" };
    var newTables = ds.Tables[0].AsEnumerable()
        .GroupBy(r => r.Field<string>("Column1"))
        .Where(g => valuesNeeded.Contains(g.Key))
        .Select(g => g.CopyToDataTable())
        .ToArray();
    ds.Tables.Clear(); // if you need to clear it first
    ds.Tables.AddRange( newTables );
    
