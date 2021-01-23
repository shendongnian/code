	[TestMethod]
	public void VBAWorksheetCopyTest()
	{
		var sb = new StringBuilder();
		sb.AppendLine("Private Sub Test()");
		sb.AppendLine("    Range(\"G10\").Value = \"TEST\"");
		sb.AppendLine("End Sub");
		var existingFile = new FileInfo(@"c:\temp\temp1.xlsm");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			workbook.CreateVBAProject();
			var worksheet = workbook.Worksheets.Add("templateSheet");
			//Module saved in the workSHEET
			worksheet.CodeModule.Code = sb.ToString();
			worksheet.CodeModule.Name = "templateSheet";
			worksheet.Cells["A1"].Value = "Col1";
			worksheet.Cells["A2"].Value = "sdf";
			worksheet.Cells["A3"].Value = "wer";
			package.Save();
		}
		//Open temp1.xlsm and copy the sheet
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			var templateSheet = workbook.Worksheets["templateSheet"];
			var someName = workbook.Worksheets.Add("someName", templateSheet);
			//VBA code does seem to copy but dose NOT match what is seen in excel
			Assert.IsTrue(templateSheet.CodeModule.Code.Length > 0);
			Assert.IsTrue(someName.CodeModule.Code.Length > 0);
			package.Save();
		}
		//Open temp1 and try to name the modules
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			var templateSheet = workbook.Worksheets["templateSheet"];
			var someName = workbook.Worksheets["someName"];
			//Give it a name otherwise Excel autonames it 'newsheet1'
			someName.CodeModule.Name = "someName"; //BUT will cause both CodeModule objects to go null
			//These will now fail becuase codemodule is now null for both
			Assert.IsTrue(templateSheet.CodeModule.Code.Length > 0);
			Assert.IsTrue(someName.CodeModule.Code.Length > 0);
		}
	}
