    FileInfo fi = new FileInfo(@"c:\File.xlsx");
    
    using (ExcelPackage package = new ExcelPackage(fi))
    {
           
        ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheets"];
         
        worksheet.Cells[1, 1].IsRichText = true;
        ExcelRichText richtext = worksheet.Cells[1, 1].RichText.Add("Test Italic");
        richtext .Italic = true;
    
        richtext = worksheet.Cells[1, 1].RichText.Add("Test 2");
        richtext .Italic = false;
    
        package.Save();
    }
