    List<Entry> FromDb()
    {
        List<Entry> res;
        using (var dbContext = new MyEntities()
        {
            res = dbContext.Where(e=>MeetsMyFilterCriteria(e)).ToList()
        }
        return res;
    }
    Main()
    {
        FileInfo fileInfo = new FileInfo("path/to/excelTemplateFile.xlsx");
        using (var excelPackage = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet sheet = excelPackage.Workbook.Worksheets["MyWorksheenName"];
            BaseRange startRange = sheet.Range["A2"] //or wherever data is to go
            int offset=0;
            foreach (entry in FromDb())
            {
                startRange.Offset(offset,0).Value = entry.PropertyA;
                startRange.Offset(offset,1).Value = entry.PropertyB;
                startRange.Offset(offset,2).Value = entry.PropertyC;
                // and so on ...
                offset++;
            }
            excelPackage.SaveAs("path/to/excelOutput.xls");
        }
    }
