	[TestMethod]
	public void Template_Copy_Test()
	{
		//http://stackoverflow.com/questions/28722945/epplus-with-a-template-is-not-working-as-expected
		const string templatePath = "c:\\temp\\testtemplate.xlsx"; // the path of the template
		const string resultPath = "c:\\temp\\result.xlsx"; // the path of our result
		//Throw in some data
		var dtdata = new DataTable("tblData");
		dtdata.Columns.Add(new DataColumn("Col1", typeof(string)));
		dtdata.Columns.Add(new DataColumn("Col2", typeof(int)));
		dtdata.Columns.Add(new DataColumn("Col3", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtdata.NewRow();
			row["Col1"] = "String Data " + i;
			row["Col2"] = i * 10;
			row["Col3"] = i * 100;
			dtdata.Rows.Add(row);
		}
		var templateFile = new FileInfo(templatePath);
		if (templateFile.Exists)
			templateFile.Delete();
		using (var pck = new ExcelPackage(templateFile))
		{
			var ws = pck.Workbook.Worksheets.Add("Data");
			ws.Cells["A1"].LoadFromDataTable(dtdata, true);
			for (var i = 2; i <= dtdata.Rows.Count + 1; i++)
				ws.Cells[i, 4].Formula = String.Format("{0}*{1}", ExcelCellBase.GetAddress(i, 2), ExcelCellBase.GetAddress(i, 3));
			ws.Tables.Add(ws.Cells[1, 1, dtdata.Rows.Count + 1, 4], "TestTable");
			pck.Save();
		}
		using (var pck = new ExcelPackage(new FileInfo(resultPath), templateFile)) // creating a package with the given template, and our result as the new stream
		{
			// note that I am not doing any work ...
			pck.Save(); // savin our work
		}
	}
