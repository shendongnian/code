    MemoryStream ms = new MemoryStream();
    using (FileStream fs = File.OpenRead(@"Path\Test.xlsx")
    using (ExcelPackage excelPackage = new ExcelPackage(fs))
    {
    	ExcelWorkbook excelWorkBook = excelPackage.Workbook;
    	ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets.First();
    	excelWorksheet.Cells[1, 1].Value = "Test";
    	excelWorksheet.Cells[3, 2].Value = "Test2";
    	excelWorksheet.Cells[3, 3].Value = "Test3";
    	
    	excelPackage.SaveAs(ms); // This is the important part.
    }
    
    ms.Position = 0;
    return new FileStreamResult(ms, "application/xlsx")
    {
    	FileDownloadName = "Tester.xlsx"
    };
