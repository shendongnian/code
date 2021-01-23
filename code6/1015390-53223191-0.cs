    using (ExcelPackage excelEngine = new ExcelPackage())
    {
         excelEngine.Workbook.Worksheets.Add("sheet1");
         excelEngine.Workbook.Worksheets.Add("sheet2");
         excelEngine.Workbook.Worksheets.Add("sheet3");
    
         String myFile= "c:\....\xx.xlsx";
         excelEngine.SaveAs();
    
    }
