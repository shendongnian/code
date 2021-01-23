	[TestMethod]
	public void TempFolderTest()
	{
		var path = Path.Combine(Path.GetTempPath(), "temp.xlsx");
		var tempfile = new FileInfo(path);
		if (tempfile.Exists)
			tempfile.Delete();
		//Save the file
		using (var pck = new ExcelPackage(tempfile))
		{
			var ws = pck.Workbook.Worksheets.Add("Demo");
			ws.Cells[1, 2].Value = "Excel Test";
			pck.Save();
		}
		//open the file
		Process.Start(tempfile.FullName);
	}
	
