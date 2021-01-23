    static DataTable MergeDataTables(DataTable dt1, DataTable dt2)
    {
         DataTable dt3 = dt1.Copy();
         foreach (DataColumn dc in dt2.Columns)
         {
             dt3.Columns.Add(dc.ColumnName).DataType = dc.DataType;
         }
    
         for (int i = 0; i < dt3.Rows.Count; i++)
         {
             foreach (DataColumn dc in dt2.Columns)
             {
                 string col = dc.ColumnName;
                 dt3.Rows[i][col] = dt2.Rows[i][col];
             }
         }
         return dt3;
    }
