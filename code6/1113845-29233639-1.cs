	[TestMethod]
	public void TotalRows_Format_Test()
	{
		//Throw in some data
		const string SomeName = "Totals";
		var dtMain = new DataTable("tblData");
		dtMain.Columns.Add(new DataColumn("Col1", typeof(int)));
		dtMain.Columns.Add(new DataColumn("Col2", typeof(int)));
		dtMain.Columns.Add(new DataColumn("Col3", typeof(int)));
		dtMain.Columns.Add(new DataColumn(SomeName, typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtMain.NewRow();
			row["Col1"] = i;
			row["Col2"] = i * 10;
			row["Col3"] = i * 100;
			dtMain.Rows.Add(row);
		}
		FileInfo newFile = new FileInfo(@"C:\Temp\Temp.xlsx");
		if (newFile.Exists)
			newFile.Delete();
		using (ExcelPackage package = new ExcelPackage(newFile))
		{
			//Create the Worksheet
			var sheet = package.Workbook.Worksheets.Add("Sheet1");
			//Read the table into a sheet
			var range = sheet.Cells["A1"].LoadFromDataTable(dtMain, true);
			sheet.Tables.Add(range, "data");
			//Now format the table...
			var tbl = sheet.Tables[0];
			//create a custom style
			string stylename = "StyleName";
			var style = package.Workbook.Styles.CreateNamedStyle(stylename);
			//Add formula for row total in COLUMN
			for (var i = 2; i <= dtMain.Rows.Count + 1; i++)
				sheet.Cells[i, 4].Formula = String.Format("SUM(A{0}:C{0})", i);
			//The totals row at the BOTTOM of the table
			tbl.Columns[SomeName].TotalsRowFunction = RowFunctions.Sum;
			tbl.ShowTotal = true;
			style.Style.Numberformat.Format = "#,###.00";
			//assign the style to the column
			tbl.Columns[SomeName].DataCellStyleName = stylename;
		range.AutoFitColumns();
		// save our new workbook and we are done!
		package.Save();
		}
	}
