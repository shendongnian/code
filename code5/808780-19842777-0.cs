    var query = (from DataColumn col in stationTable.Columns
                from DataRow row in stationTable.Rows
                where col.ColumnName.StartsWith("B_")
                select new { Row = row[col.ColumnName], col.ColumnName })
                .ToLookup(o => o.ColumnName, o => o.Row);
    
    foreach (var group in query)
    {
        Console.WriteLine("ColumnName: {0}", group.Key);
        foreach (var item in group)
        {
            Console.WriteLine(item);
        }
    }
