    var rows = possibleRows.Cast<DataRow>();
    var averages = table.Columns.Cast<DataColumn>()
        .Select(col => new {
            Column = col,
            Average = rows.Average(row => (double)row[col])
        }).ToList();
