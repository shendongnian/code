    var fileInfo = new FileInfo(filename);
    using(var excelPackage = new OfficeOpenXml.ExcelPackage(fileInfo))
    {
    	foreach (var sheet in excelPackage.Workbook.Worksheets)
    	{
    		foreach (ExcelTable table in sheet.Tables)
    		{
    			ExcelCellAddress start = table.Address.Start;
    			ExcelCellAddress end = table.Address.End;
    
    			for (int row = start.Row; row <= end.Row; ++row)
    			{
    				ExcelRange range = sheet.Cells[row, start.Column, row, end.Column];
    				...
    			}
    		}
    	}
    }
