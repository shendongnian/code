    var rows = dt.AsEnumerable();
    var firstCol = string.Join(",", rows.Select(r => r.Field<string>(0)));
    var otherColumns = dt.Columns.Cast<DataColumn>().Skip(1)
        .Select(dc => string.Format("{0},{1}", 
            dc.ColumnName, 
            string.Join(",", rows.Select(r => r.Field<string>(dc)))));
    string sDataTableOutput = string.Format("{0}|{1}", 
        firstCol, 
        string.Join("|", otherColumns));
