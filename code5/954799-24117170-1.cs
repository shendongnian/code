    public static void ClearCells(string SpreadsheetFilePath)
    {
        var excelFile = new FileInfo(SpreadsheetFilePath);
        var excelPack = ExcelPackage(excelFile);
        
        var workSheet = excelPack.Workbook.Worksheets.Add("Content"); // New worksheet           
        workSheet.Cells[1, 1].Value = "hello123";
        
        excelPack.Save();
    }
