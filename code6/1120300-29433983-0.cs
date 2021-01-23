        DataTable dtResult = new DataTable();
        DataColumn col = null;
        string ColName = string.Empty;
        int i;
        int ColCnt = 1;
        dtResult.Clear();
        dtResult.Columns.Clear();
        for (i = 0; i < dtTab1.Columns.Count; i++)
        {
            ColName = dtTab1.Columns[i].ColumnName;
            col = new DataColumn(ColName);
            col.DataType = System.Type.GetType("System.String");
            dtResult.Columns.Add(col);
            ColCnt++;
        }
        for (i = 0; i < dtTab2.Columns.Count; i++)
        {
            ColName = dtTab2.Columns[i].ColumnName;
            col = new DataColumn(ColName);
            col.DataType = System.Type.GetType("System.String");
            dtResult.Columns.Add(col);
            ColCnt++;
        }
       
            object[] elems = new object[dtTab1.Columns.Count + dtTab2.Columns.Count];
            for (int r = 0; r < Math.Min(dtTab1.Rows.Count, dtTab2.Rows.Count); r++)
            {
                DataRow r1 = dtTab1.Rows[r];
                DataRow r2 = dtTab2.Rows[r];
                DataRow row ;
                int q = 0;
                for (; q < dtTab1.Columns.Count; q++)
                
                    elems[q] = r1.ItemArray[q];
                
                int z = 0;
                for (; z < dtTab2.Columns.Count; z++)
                
                    elems[q + z] = r2.ItemArray[z];
                
                row = dtResult.NewRow();
                row.ItemArray = elems;
                dtResult.Rows.Add(row);
            }
                
              
        
