    var ds = [Your dataset here];
    Worksheet objWorkSheet1 = null;
    Application objExcel = new Application {Visible = false};
    Workbooks objWorkbooks = objExcel.Workbooks;
    Workbook objWorkbook = objWorkbooks.Add(Missing.Value);
    Sheets objSheets = objWorkbook.Worksheets;
    
    if (ds.Tables.Count > objSheets.Count)
    {
    	// add extra sheets
    	for (var i = objSheets.Count; i < ds.Tables.Count; i++)
    	{
    		var objWorkSheet2 = (Worksheet)objSheets[i];
    		objWorkSheet1 = (Worksheet)objSheets.Add(Missing.Value, objWorkSheet2, 1, XlSheetType.xlWorksheet);
    		Marshal.ReleaseComObject(objWorkSheet2);
    		Marshal.ReleaseComObject(objWorkSheet1);
    		objWorkSheet1 = null;
    	}
    }
    while (ds.Tables.Count < objSheets.Count)
    {
    	// remove unnecessary sheets
    	var objWorkSheet2 = (Worksheet)objSheets[ds.Tables.Count];
    	objWorkSheet2.Delete();
    	Marshal.ReleaseComObject(objWorkSheet2);
    }
    Range objCells;
    Range myCell;
    for (var t = 0; t < ds.Tables.Count; t++)
    {// for each table in the dataset fill in the sheet 
    	var iCurrentRow = 1;
    	var dt = ds.Tables[t];
    	objWorkSheet1 = (Worksheet)(objSheets[t + 1]);
    	objCells = objWorkSheet1.Cells;
    	
        //Start writing the table to the worksheet
        // Get the sheet and write the headers
	    for (var h = 0; h < dt.Columns.Count; h++)
    	{
    		myCell = (Range)objCells[iCurrentRow, h + 1];
    		myCell.Value2 = dt.Columns[h].ColumnName;
    		Marshal.ReleaseComObject(myCell);
    	}
    	iCurrentRow++;
    	// write the data rows
    	for (var r = 0; r < dt.Rows.Count; r++)
    	{
    		// Get the sheet and write the headers
    		for (var c = 0; c < dt.Columns.Count; c++)
    		{
    			myCell = (Range)objCells[r + iCurrentRow, c + 1];
    			myCell.Value2 = dt.Rows[r][c].ToString();
    			Marshal.ReleaseComObject(myCell);
    		}
    	}
    	Marshal.ReleaseComObject(objCells);
    	objCells = null;
    	Marshal.ReleaseComObject(objWorkSheet1);
    	objWorkSheet1 = null;
    }
    //End writing the data table to the sheet
    // select the first cell in the first sheet
    objWorkSheet1 = (Worksheet)(objSheets[1]);
    objCells = objWorkSheet1.Cells;
    myCell = (Range)objCells[1, 1];
    Marshal.ReleaseComObject(myCell);
    myCell = null;
    Marshal.ReleaseComObject(objCells);
    objCells = null;
    Marshal.ReleaseComObject(objWorkSheet1);
    objWorkSheet1 = null;
    
    // save the file to the new location with new name.
    objWorkbook.Close(true, [your filename here to save to], Missing.Value);
    
    objWorkbooks.Close();
    objExcel.Quit();
