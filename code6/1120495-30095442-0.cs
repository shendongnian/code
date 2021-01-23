     var ws = MainExcel.Workbook.Worksheets.First();
     DataTable tbl = new DataTable();
     for (var rowNum = 1; rowNum <= ws.Dimension.End.Row; rowNum++)      
     {
         var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
         var array = wsRow.Value as object[,];
                  
         var row = tbl.NewRow();
         int hhh =0;
                        
         foreach (var cell in wsRow)
              {
               cell.Style.Numberformat.Format = "@";
               row[cell.Start.Column - 1] = cell.Text;
              }
         tbl.Rows.Add(row);
     }
