    var ReadExcel = new System.Data.DataTable();
    var UsedRange = xlWorksheet.UsedRange;
    // Add a new column to the DataTable
    var column = new DataColumn();
    column.ColumnName = "rowValue";
    ReadExcel.Columns.Add(column);
    foreach (Range row in xlWorksheet.Rows)
    {               
        var newrow = ReadExcel.NewRow();
        // Add row.Value NOT xlWorksheet.Rows.Value
        newrow["rowValue"] = row.Value;
        ReadExcel.Rows.Add(newrow);
    }
