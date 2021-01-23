    foreach (DataColumn column in table.Columns)
    {
        grid.Columns.Add(column.ColumnName, column.ColumnName);
    }
    
    grid.Rows.Add(table.Rows.count);
    Int32 i=0;
    foreach (DataRow rw in table.Rows)
    {
    grid.Rows[i].Cell[0].value = rw["col1"].ToString();
    i+=1;
    
    }
