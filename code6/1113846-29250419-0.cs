	FileInfo newFile = new FileInfo(@"C:\Temp.xslx");
	using (ExcelPackage package = new ExcelPackage(newFile))
	{
		//Create the Worksheet
		var sheet = package.Workbook.Worksheets.Add("Sheet1");
		//Read the table into a sheet
		var range = sheet.Cells["A1"].LoadFromDataTable(dtMain, true);
		sheet.Tables.Add(range, "data");
		//Now format the table...
		var tbl = sheet.Tables[0];
		tbl.ShowTotal = true;
		//create a custom style
		string stylename = "StyleName";
		var style = package.Workbook.Styles.CreateNamedStyle(stylename);
		tbl.Columns[SomeName].TotalsRowFunction = RowFunctions.Sum;
		style.Style.Numberformat.Format = "#,###.00";
		//apply style to totals row
		sheet.Cells[sheet.Dimension.End.Row, colcount].Style.Numberformat.Format = c.Format;
		//assign the style to the column
		tbl.Columns[SomeName].DataCellStyleName = stylename;
	}
	range.AutoFitColumns();
	// save our new workbook and we are done!
	package.Save();
