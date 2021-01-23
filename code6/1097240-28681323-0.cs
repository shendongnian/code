	[TestMethod]
	public void Cell_Color_Background_Test()
	{
		//http://stackoverflow.com/questions/28679602/how-to-set-cell-color-programmatically-epplus
		
		//Throw in some data
		var dtdata = new DataTable("tblData");
		dtdata.Columns.Add(new DataColumn("Col1", typeof(string)));
		dtdata.Columns.Add(new DataColumn("Col2", typeof(int)));
		dtdata.Columns.Add(new DataColumn("Col3", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtdata.NewRow();
			row["Col1"] = "Available";
			row["Col2"] = i * 10;
			row["Col3"] = i * 100;
			dtdata.Rows.Add(row);
		}
		//throw in one cell that triggers
		dtdata.Rows[10]["Col1"] = "Annual leave";
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			//Using EPPLUS to export Spreadsheets
			var ws = pck.Workbook.Worksheets.Add("Availability list");
			ws.Cells["A1"].LoadFromDataTable(dtdata, true);
			ws.Cells["A1:G1"].Style.Font.Bold = true;
			ws.Cells["A1:G1"].Style.Font.UnderLine = true;
			//change cell color depending on the text input from stored proc?
			//if (dtdata.Rows[4].ToString() == "Annual Leave")
			for (var i = 0; i < dtdata.Rows.Count; i++)
			{
				if (dtdata.Rows[i]["Col1"].ToString() == "Annual leave")
				{
					ws.Cells[i + 1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					ws.Cells[i + 1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
				}
			}
			pck.Save();
		}
