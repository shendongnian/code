    var rptTable = from t in ReportConfigurationTable.AsEnumerable()
        				   select new {Type = t["Type"], Product = t["Product"], Action = t["Action"], Quantity = t["Quantity"]};
        	
        	
    var tableColumnGrouping = from table in rptTable
                                 group table by new { table.Type, table.Product }
                                     into groupedTable
                                     select new
                                     {
                                         tableColumn = groupedTable.Key,
                                         tableColumnCount = groupedTable.Count(),
                                         actions = groupedTable.Select(t => new {Action = t.Action, Quantity = t.Quantity})
                                     };
