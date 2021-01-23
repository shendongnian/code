    DataTable tbl = ExcelDataSet.Tables[0];
    foreach (DataRow row in tbl.Rows)
    {
        foreach(DataColumn col in tbl.Columns)
        {
            row.SetField(col, row.IsNull(col) ? "" : row[col].ToString());
        }
    }
