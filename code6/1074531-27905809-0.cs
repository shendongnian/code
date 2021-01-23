    var bLookup = new HashSet<string>(dtA.AsEnumerable().Select(r => r.Field<string>("ColumnB")));
    foreach(DataRow row in dtB.Rows)
    {
        string value = row.Field<string>("ColumnA");
        if(bLookup.Contains(value))
        {
            // write to log
        }
    }
