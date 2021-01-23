    foreach (DataColumn column in myDataTable.Columns)
    {
        foreach (DataRow row in myDataTable.Rows)
        {
            var valueByColumn = row[column];
            var valueByColumnName = row[column.ColumnName];
    
            // ...
        }
    }
