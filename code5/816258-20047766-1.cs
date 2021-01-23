    var columnsList = dtAllRows.AsEnumerable()
                      .SelectMany(row=>dtAllRows.Columns.Cast<DataColumn>()
                                                .Select(col=>Convert.ToString(row[col])))
                      .ToList();
    //Example:
    //A1   B1
    //A2   B2
    //-> List<string> {"A1","B1","A2","B2"}
