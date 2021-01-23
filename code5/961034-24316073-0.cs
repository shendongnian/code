    DataTable MergeDataTables(DataTable dt1, DataTable dt2)
        {
            var dtResult = new DataTable();
           
            foreach (DataColumn col in dt1.Columns)
                dtResult.Columns.Add(col.ColumnName, col.DataType);
            foreach (DataColumn col in dt2.Columns)
                dtResult.Columns.Add(col.ColumnName, col.DataType);
              
            //cond: to check which if datatable1 is bigger
            if (dt1.Rows.Count > dt2.Rows.Count)
            {               
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (i < dt2.Rows.Count)
                        dtResult.Rows.Add(dt1.Rows[i].ItemArray.Concat(dt2.Rows[i].ItemArray).ToArray());
                    else
                    {
                        DataRow dr = dtResult.NewRow();
                        foreach (DataColumn col in dt1.Columns)                       
                            dr[col.ColumnName] = dt1.Rows[i][col.ColumnName];
                        dtResult.Rows.Add(dr);
                    }                
                }
            }
            //if rows equal or datatable2 is bigger
            else
            {                
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (i < dt1.Rows.Count)
                        dtResult.Rows.Add(dt1.Rows[i].ItemArray.Concat(dt2.Rows[i].ItemArray).ToArray());
                    else
                    {
                        DataRow dr = dtResult.NewRow();
                        foreach (DataColumn col in dt2.Columns)                                                  
                            dr[col.ColumnName] = dt2.Rows[i][col.ColumnName];
                        dtResult.Rows.Add(dr);
                    }
                }                
            }
           
           return dtResult;
        } 
