    DataTable tblOld = ExcelDataSet.Tables[0];
    DataTable tblNew = new DataTable();
    foreach (DataColumn col in tblOld.Columns)
        tblNew.Columns.Add(col.ColumnName);
    foreach (DataRow rowOld in tblOld.Rows)
    {
        DataRow rowNew = tblNew.Rows.Add();
        foreach (DataColumn col in tblOld.Columns)
        {
            rowNew.SetField(col.ColumnName, rowOld.IsNull(col) ? "" : rowOld[col].ToString());
        }
    } 
    return tblNew;
