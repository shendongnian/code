    void Main()
    {
    	var existingFile = new FileInfo(@"c:\temp\book1.xlsx");
    	// Open and read the XlSX file.
    	using (var package = new ExcelPackage(existingFile))
    	{
    		// Get the work book in the file
    		ExcelWorkbook workBook = package.Workbook;
    		if (workBook != null)
    		{
    			if (workBook.Worksheets.Count > 0)
    			{
    				// Get the first worksheet
    				ExcelWorksheet sheet = workBook.Worksheets.First();
    	
    				// read some data
    				Dictionary<string,double> cells = (from cell in sheet.Cells["A1:B6"] 
    							where cell.Start.Column == 1
    							select sheet.Cells[cell.Start.Row,cell.Start.Column,cell.Start.Row,2].Value)
    							.Cast<object[,]>()
    							.ToDictionary (k => k[0,0] as string, v => (double)(v[0,1]));
    							
    				//do what you need to do with the dictionary here....!
    			}
    		}
    	}
    
    }
