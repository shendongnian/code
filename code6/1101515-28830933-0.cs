    DataTable tbl1 = dataSet.Tables[0];
    DataTable tbl2 = dataSet.Tables[1];
    tbl1.Columns.Add("sumcredit");
    
    foreach (DataRow dr in tbl1.Rows) {
        
    IntegrateRow(dr, tbl2);
    }
    public void IntegrateRow(DataRow dr1, DataTable tbl2)
            {
                try
                {
                 foreach (DataRow dr in tbl2.Rows) {
                    foreach (DataColumn v_Column in dr.Table.Columns)
                    {
                        string ColumnName = v_Column.ColumnName;
                        if (dr1.Table.Columns.Contains(ColumnName))
                        {
                            dr1[ColumnName] = dr[ColumnName];
                        }
                    }
                  }
                }
                catch (Exception e)
                {
    
                }
