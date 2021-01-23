	[TestMethod]
	public void MergeCellTest()
	{
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			var worksheet = workbook.Worksheets.Add("newsheet");
			worksheet.Select("A1:C3");
			worksheet.SelectedRange.Merge = true;
			worksheet.SelectedRange.Value = "toto";
			package.Save();
		}
	}
