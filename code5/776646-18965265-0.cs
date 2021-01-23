	public void ExcelOpenSpreadsheets(string databaseStoredExcelFileName, int worksheetNumber, string startRange, string endRange)
	{
		try
		{
			Workbook workBook = _excelApp.Workbooks.Open(databaseStoredExcelFileName,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);
			var worksheet = workbook.Worksheets[worksheetNumber] as Microsoft.Office.Interop.Excel.Worksheet;
			
			Excel.Range range = worksheet.get_Range(startRange, endRange);
			workBook.Close(false, thisFileName, null);
			Marshal.ReleaseComObject(workBook);
			
			//now do something with "range"
		}
		catch
		{
		}
	}
