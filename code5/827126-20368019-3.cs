    var columnNames = new[]{"IsMonday","Istuesday","IsWednesday"};
    var rows = dt.AsEnumerable()
                 .Select(row=>string.Join("", 
                              dt.Columns.Cast<DataColumn>()
                                .Where(col=>columnNames.Contains(col.ColumnName))
                                .Select(col=>row.Field<string>(col) == "N" ? " " :
                                             (col.Ordinal+1).ToString()))).ToList();
