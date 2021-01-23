    DataTable tbl1 = dataSet.Tables[0];
    DataTable tbl2 = dataSet.Tables[1];
    tbl1.Columns.Add("sumcredit");
    
    for (int i = 0; i < tbl2.Rows.Count; i++)
    {
        DataRow dr = tbl2.Rows[i];
        DataRow dr1 = tbl1.Rows[i];
        foreach (DataColumn v_Column in dr.Table.Columns)
        {
            if (dr1.Table.Columns.Contains("sumcredit"))
            {
                dr1["sumcredit"] = dr["sumcredit"];
            }
        }
    }
