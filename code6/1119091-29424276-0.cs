	[TestMethod]
	public void Sheet_Gridline_Color_Test()
	{
		//http://stackoverflow.com/questions/29380587/set-gridline-color-using-epplus
		//Throw in some data
		var dtMain = new DataTable("tblData");
		dtMain.Columns.Add(new DataColumn("Col1", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtMain.NewRow();
			row["Col1"] = i;
			dtMain.Rows.Add(row);
		}
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			var ws = pck.Workbook.Worksheets.Add("Content");
			ws.Cells["A1"].LoadFromDataTable(dtMain, true);
			//Can get xml elements quick and dirty using relative childs but should do a proper search in production
			var wsxd = ws.WorksheetXml;
			var wsxml = wsxd.LastChild; //gets 'worksheet'
			var sheetViewsXml = wsxml.FirstChild; //gets 'sheetViews'
			var sheetViewXml = sheetViewsXml.FirstChild; //gets 'sheetView'
			var att = wsxd.CreateAttribute("defaultGridColor");
			att.Value = "0";
			sheetViewXml.Attributes.Append(att);
			att = wsxd.CreateAttribute("colorId");
			att.Value = "10";
			sheetViewXml.Attributes.Append(att);
			pck.Save();
		}
	}
