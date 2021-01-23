     Also refer [MSDN][1]   
    // Create total column.
    DataColumn totalColumn = new DataColumn();
    totalColumn.DataType = System.Type.GetType("System.Decimal");
    totalColumn.ColumnName = "total";
    totalColumn.Expression = "Price+ Quantity";
    
    // Add columns to DataTable.
    ...
    table.Columns.Add(totalColumn);
