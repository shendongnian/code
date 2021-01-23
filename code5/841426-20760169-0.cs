    private void CreateExcel(DataTable dataTable)
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
    
                    ws.Cells["A1"].LoadFromDataTable(dataTable, true);                
    
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
                    Response.BinaryWrite(pck.GetAsByteArray());
                }
            }
