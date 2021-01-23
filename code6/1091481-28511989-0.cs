	[TestMethod]
	public void Condition_Read_Test()
	{
		//http://stackoverflow.com/questions/28493050/importing-excel-file-with-all-the-conditional-formatting-rules-to-epplus
		//File with custom conditional formatting
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		//Copy of the file with the conditonal formatting removed
		var existingFile2 = new FileInfo(@"c:\temp\temp2.xlsx");
		using (var package = new ExcelPackage(existingFile))
		using (var package2 = new ExcelPackage(existingFile2))
		{
			//get the extension list node 'extLst' from the ws with the formatting
            //probably shouldnt just assume it is always last and do a proper search
			var worksheet = package.Workbook.Worksheets.First();
			var xdoc = worksheet.WorksheetXml;
			var extensionlistnode = xdoc.LastChild.LastChild;
			//Get the xml document for the destination worksheet
			var worksheet2 = package2.Workbook.Worksheets.First();
			var xdoc2 = worksheet2.WorksheetXml;
			//Create the import node and append it to the end of the xml document
			var newnode = xdoc2.ImportNode(extensionlistnode, true);
			xdoc2.LastChild.AppendChild(newnode);
			package2.Save();
		}
	}
