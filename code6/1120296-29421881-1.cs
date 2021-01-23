    DataTable dtResult = new DataTable();
    foreach (DataColumn col in dtTab1.Columns)
        dtResult.Columns.Add(col.ColumnName, col.DataType);
    foreach (DataColumn col in dtTab2.Columns)
        dtResult.Columns.Add(col.ColumnName, col.DataType);
    for (int r = 0; r < Math.Min(dtTab1.Rows.Count, dtTab2.Rows.Count); r++)
    {
        DataRow r1 = dtTab1.Rows[r];
        DataRow r2 = dtTab2.Rows[r];
        DataRow row = dtResult.Rows.Add();
        foreach (DataColumn col in dtTab1.Columns)
            row.SetField(col.ColumnName, r1[col]);
        foreach (DataColumn col in dtTab2.Columns)
            row.SetField(col.ColumnName, r2[col]);
    }
