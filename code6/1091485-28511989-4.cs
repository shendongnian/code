	[TestMethod]
	public void Custom_Condition_From_String_Test()
	{
		//http://stackoverflow.com/questions/28493050/importing-excel-file-with-all-the-conditional-formatting-rules-to-epplus
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.Add(new DataColumn("Col1", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col2", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col3", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = datatable.NewRow();
			row["Col1"] = i;
			row["Col2"] = i * 10;
			row["Col3"] = i * 100;
			datatable.Rows.Add(row);
		}
		//Copy of the file with the conditonal formatting removed
		var existingFile2 = new FileInfo(@"c:\temp\temp2.xlsx");
		if (existingFile2.Exists)
			existingFile2.Delete();
		using (var package2 = new ExcelPackage(existingFile2))
		{
			//Add the data
			var ws = package2.Workbook.Worksheets.Add("Content");
			ws.Cells.LoadFromDataTable(datatable, true);
			
			//The XML String extracted from the orginal excel doc using '= extensionlistnode.OuterXml'
			var cellrange = "A1:C201";
			var rawxml = String.Format(
				"<extLst xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\"><ext uri=\"{{78C0D931-6437-407d-A8EE-F0AAD7539E65}}\" xmlns:x14=\"http://schemas.microsoft.com/office/spreadsheetml/2009/9/main\"><x14:conditionalFormattings><x14:conditionalFormatting xmlns:xm=\"http://schemas.microsoft.com/office/excel/2006/main\"><x14:cfRule type=\"iconSet\" priority=\"2\" id=\"{{CD6B2710-0474-449D-881A-22CFE15D011D}}\"><x14:iconSet iconSet=\"5Arrows\" custom=\"1\"><x14:cfvo type=\"percent\"><xm:f>0</xm:f></x14:cfvo><x14:cfvo type=\"percent\"><xm:f>20</xm:f></x14:cfvo><x14:cfvo type=\"percent\"><xm:f>40</xm:f></x14:cfvo><x14:cfvo type=\"percent\"><xm:f>60</xm:f></x14:cfvo><x14:cfvo type=\"percent\"><xm:f>80</xm:f></x14:cfvo><x14:cfIcon iconSet=\"3Symbols\" iconId=\"0\" /><x14:cfIcon iconSet=\"3TrafficLights1\" iconId=\"0\" /><x14:cfIcon iconSet=\"3Triangles\" iconId=\"0\" /><x14:cfIcon iconSet=\"3Triangles\" iconId=\"1\" /><x14:cfIcon iconSet=\"3Triangles\" iconId=\"2\" /></x14:iconSet></x14:cfRule><xm:sqref>{0}</xm:sqref></x14:conditionalFormatting></x14:conditionalFormattings></ext></extLst>"
				, cellrange);
			
			var newxdoc = new XmlDocument();
			newxdoc.LoadXml(rawxml);
			//Create the import node and append it to the end of the xml document
			var xdoc2 = ws.WorksheetXml;
			var newnode = xdoc2.ImportNode(newxdoc.FirstChild, true);
			xdoc2.LastChild.AppendChild(newnode);
			package2.Save();
		}
	}
