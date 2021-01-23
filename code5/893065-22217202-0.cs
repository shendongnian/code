    private void DumpExcel(DataTable tbl)
    {
       using (ExcelPackage pck = new ExcelPackage())
       {
         //Create the worksheet
         ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
        
    
         //Load the datatable into the sheet, starting from cell A1.
         ws.Cells["A1"].LoadFromDataTable(tbl, true);
         ExcelWorksheet.InsertRow(int rowFrom, int rows, intCopyStylesFromRow);
    
         Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
         Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
         Response.BinaryWrite(pck.GetAsByteArray());
        }
     }
