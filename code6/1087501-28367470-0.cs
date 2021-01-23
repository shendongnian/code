	[TestMethod]
	public void DeleteColumn_Test()
	{
		//http://stackoverflow.com/questions/28359165/how-to-remove-a-column-from-excel-sheet-in-epplus
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.Add(new DataColumn("Col1"));
		datatable.Columns.Add(new DataColumn("Col2"));
		datatable.Columns.Add(new DataColumn("Col3"));
		for (var i = 0; i < 20; i++)
		{
			var row = datatable.NewRow();
			row["Col1"] = "Col1 Row" + i;
			row["Col2"] = "Col2 Row" + i;
			row["Col3"] = "Col3 Row" + i;
			datatable.Rows.Add(row);
		}
		using (var pack = new ExcelPackage(existingFile))
		{
			var ws = pack.Workbook.Worksheets.Add("Content");
			ws.Cells.LoadFromDataTable(datatable, true);
			ws.DeleteColumn(2);
			pack.SaveAs(existingFile);
		}
	}
