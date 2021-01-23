    private static bool ConvertWithNPOI(string excelFileName, string worksheetName, IEnumerable<string[]> csvLines)
    {
        if (csvLines == null || csvLines.Count() == 0)
        {
    	return (false);
        }
    
        int rowCount = 0;
        int colCount = 0;
    
        IWorkbook workbook = new XSSFWorkbook();
        ISheet worksheet = workbook.CreateSheet(worksheetName);
    
        foreach (var line in csvLines)
        {
    	IRow row = worksheet.CreateRow(rowCount);
    
    	colCount = 0;
    	foreach (var col in line)
    	{
    	    row.CreateCell(colCount).SetCellValue(TypeConverter.TryConvert(col));
    	    colCount++;
    	}
    	rowCount++;
        }
    
        using (FileStream fileWriter = File.Create(excelFileName))
        {
    	   workbook.Write(fileWriter);
    	   fileWriter.Close();
        }
    
        worksheet = null;
        workbook = null;
    
        return (true);
    }
