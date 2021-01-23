    private static bool ConvertWithClosedXml(string excelFileName, string worksheetName, IEnumerable<string[]> csvLines)
    {
        if (csvLines == null || csvLines.Count() == 0)
        {
    	return (false);
        }
    
        int rowCount = 0;
        int colCount = 0;
    
        using (var workbook = new XLWorkbook())
        {
    	using (var worksheet = workbook.Worksheets.Add(worksheetName))
    	{
    	    rowCount = 1;
    	    foreach (var line in csvLines)
    	    {
    		colCount = 1;
    		foreach (var col in line)
    		{
    		    worksheet.Cell(rowCount, colCount).Value = TypeConverter.TryConvert(col);
    		    colCount++;
    		}
    		rowCount++;
    	    }
    	    
    	}
    	workbook.SaveAs(excelFileName);
        }
    
        return (true);
    }
