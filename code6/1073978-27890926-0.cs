    Microsoft.Office.Interop.Excel.Range cells = reportSheet.Cells;
    // Cycle through each newline code and replace.
    foreach (var newline in new string[] { "\r\n", "\r", "\n" })
    {
    	cells.Replace(newline, "",
    				  Microsoft.Office.Interop.Excel.XlLookAt.xlWhole,
    				  Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, false,
    				  false, true, false);
    }
