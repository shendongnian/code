    var lookup = new HashSet<string>(dtA.AsEnumerable().Select(r => r.Field<string>("ColumnB")));
    foreach(DataRow row in dtB.Rows)
    {
        string value = row.Field<string>("ColumnA");
        if(lookup.Contains(value))
        {
            // write to log
        }
    }
