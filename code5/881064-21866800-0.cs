    StringBuilder strb = new StringBuilder();
    foreach (DataColumn column in ds.Tables[0].Columns)
    {
        strb.Append(column.ColumnName);
        strb.Append(",");
    }
    strb.Append("\n")
    foreach (DataRow dr in ds.Tables[0].Rows)
    {
        for (int i=0; i<dr.ItemArray.Length; i++)
        {
            strb.Append(dr[i].ToString());
            strb.Append(",");
        }
        strb.Append("\n")
    }
