    foreach (DataColumn col in inputTable.Columns)
    {
    outputTable.Columns.Add(col.ColumnName, typeof(string));
    
    foreach (DataRow row in inputTable.Rows)
    {
    outputTable.Columns.Add(row.toString());
    }
    }
