    private static DataTable MergeTables(DataTable dt1, DataTable dt2)
    {
        DataTable merged = new DataTable();
        //copy column struct from dt1
        merged = dt1.Clone();
        //create columns from dt2
        foreach (DataColumn col in dt2.Columns)
        {
            merged.Columns.Add(col.ColumnName);
        }
        int rows;
        if (dt1.Rows.Count > dt2.Rows.Count)
        {
            rows = dt1.Rows.Count;
        }
        else
        {
            rows = dt2.Rows.Count;
        }
            
        for (int i = 0; i < rows; i++)
        {
            DataRow row = merged.NewRow();
            if ( i < dt1.Rows.Count)
            {
                for (int c = 0; c < dt1.Columns.Count; c++)
                {
                    row[c] = dt1.Rows[i][c];
                }
            }
            if (i < dt2.Rows.Count)
            {
                for (int c2 = dt1.Columns.Count; c2 < dt2.Columns.Count + dt1.Columns.Count; c2++)
                {
                    row[c2] = dt2.Rows[i][c2-dt1.Columns.Count];
                }
            }
            merged.Rows.Add(row);
        }
        return merged;
    }
