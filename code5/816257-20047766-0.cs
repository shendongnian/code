    var columnsList = dtAllRows.AsEnumerable()
                               .SelectMany(row=>dtAllRows.Columns.Cast<DataColumn>()
                                                         .Select(col=>(string)row[col]))
                               .ToList();
    //Example:
    //A1   B1
    //A2   B2
    //-> List<string> {"A1","B1","A2","B2"}
