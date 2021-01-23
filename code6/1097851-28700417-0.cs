	[TestMethod]
	public void Format_Single_Column_Test()
	{
		//http://stackoverflow.com/questions/28698226/formatting-a-column-with-epplus-excel-library
		var excelDocName = @"c:\temp\temp.xlsx";
		var aFile = new FileInfo(excelDocName); // excelDocName is a string
		if (aFile.Exists)
			aFile.Delete();
		ExcelPackage pck = new ExcelPackage(aFile);
		var ws = pck.Workbook.Worksheets.Add("Content");
		ws.View.ShowGridLines = true;
		ws.Cells["A:D"].Style.Numberformat.Format = null;
		ws.Cells["B:B"].Style.Numberformat.Format = "0.00";
		ws.Cells[1, 1].Value = "AA";
		ws.Cells[1, 2].Value = "BB";
		ws.Cells[1, 3].Value = "CC";
		ws.Cells[1, 4].Value = "DD";
		for (int row = 2; row <= 10; ++row)
			for (int col = 1; col <= 4; ++col)
			{
				ws.Cells[row, col].Value = row*col;
			}
		ws.Row(1).Style.Font.Bold = true;
		pck.Save();
	}
