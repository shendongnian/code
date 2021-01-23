    if(DR!=null&&DR.Any()) {
       var headerNames = DR[0].Table.Columns.Cast<DataColumn>()
                              .Select(col=>col.ColumnName).ToList();
       //remove ToList() if you want.
    }
