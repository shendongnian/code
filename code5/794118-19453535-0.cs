       foreach (DataColumn dc in excelExport.Columns)
       {                    
          if (colCount >= 2)
          {
           DataRow dr2 = newDatatable.NewRow();                                           
           dr2[0] = dr[1].ToString();
           dr2[1] = dr[2].ToString();
           dr2[2] = dc.ColumnName;
           dr2[3] = dr[colCount].ToString();
           newDatatable.Rows.Add(dr2);
          }
         colCount++;
       }
