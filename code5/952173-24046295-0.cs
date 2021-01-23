    using (SpreadsheetDocument document = SpreadsheetDocument.Open(outputPath, true)) {
    	Sheet sheet2 = document.WorkbookPart.Workbook.Descendants<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Single(s => s.Name == "Your sheet name");
        
    	DocumentFormat.OpenXml.Spreadsheet.Worksheet workSheet2 = ((WorksheetPart)document.WorkbookPart.GetPartById(sheet2.Id)).Worksheet;
    
    	// Check if the column collection exists
    	Columns cs = workSheet2.Elements<Columns>().FirstOrDefault();
    
    	if ((cs == null)) {
    		// If Columns appended to worksheet after sheetdata Excel will throw an error.
    		SheetData sd = workSheet2.Elements<SheetData>().FirstOrDefault();
    		if ((sd != null)) {
    			cs = workSheet2.InsertBefore(new Columns(), sd);
    		} else {
    			cs = new Columns();
    			workSheet2.Append(cs);
    		}
    	}
    
    	//create a column object to define the width of columns 1 to 3  
    	Column c = new Column {
    		Min = (UInt32Value)1U,
    		Max = (UInt32Value)3U,
    		Width = 44.33203125,
    		CustomWidth = true
    	};
    	cs.Append(c);
    
    }
