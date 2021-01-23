    var tableColumnGrouping = from table in ReportConfigurationTable.AsEnumerable()
                         group table by new { column1 = table["Type"], column2 = table["Product"] }
                             into groupedTable
                             select new
                             {
                                 tableColumn = groupedTable.Key,  // Each Key contains column1 and column2
                                 tableColumnCount = groupedTable.Count(),
    							 actions = groupTable.Select(new {Action = table["Action"], Quantity = tableColumnGrouping["Quantity"]})
                             };
