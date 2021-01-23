    DataTable smallTable = dataTable1.Clone(); // Copy data structure
    // Now you can remove your columns
    smallTable.Columns.Remove("Column2");
    ......
    foreach (var row in dataTable1.Rows) // iterate all rows 
    {
        var newRow = smallTable.NewRow();
        foreach (var col in smallTable.Columns) // and iterate only needed columns
        {
            newRow[col.ColumnName] = row[col.ColumnName];
        }
    }
