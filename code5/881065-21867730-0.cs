        System.Text.StringBuilder strb = new System.Text.StringBuilder();
        strb.Append("[");
        foreach (DataColumn column in ds.Tables[0].Columns)
        {
            strb.Append("'");
            strb.Append(column.ColumnName);
            strb.Append("', ");
        }
        strb.Append("],\n");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            strb.Append("[");
            for (int i=0; i<dr.ItemArray.Length; i++)
            {
                if (i == (dr.ItemArray.Length - 1))
                {
                    strb.Append(dr[i].ToString());
                }
                else
                {
                    strb.Append("'");
                    strb.Append(dr[i].ToString());
                    strb.Append("', ");
                }
            }
            strb.Append("],\n");
        }
