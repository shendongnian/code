    [TestMethod]
	public void Chart_DateTime_Test()
	{
		//http://stackoverflow.com/questions/28158702/chart-x-axis-date-and-time
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			var wsContent = pck.Workbook.Worksheets.Add("Content");
			var wsPressure = pck.Workbook.Worksheets.Add("Pressure");
			//Some data
			wsContent.Cells["A1"].Value = "A";
			wsContent.Cells["B1"].Value = "B";
			wsContent.Cells["C1"].Value = "C";
			wsContent.Cells["D1"].Value = "D";
			wsContent.Cells["A2"].Value = 1;
			wsContent.Cells["A3"].Value = 4;
			wsContent.Cells["A4"].Value = 2;
			wsContent.Cells["A5"].Value = 3;
			wsContent.Cells["A6"].Value = 6;
			wsContent.Cells["A7"].Value = 5;
			wsContent.Cells["D2"].Value = new DateTime(2015, 1, 1, 8, 15, 0);
			wsContent.Cells["D3"].Value = new DateTime(2015, 1, 1, 15, 15, 0);
			wsContent.Cells["D4"].Value = new DateTime(2015, 1, 2, 8, 15, 0);
			wsContent.Cells["D5"].Value = new DateTime(2015, 1, 3, 8, 15, 0);
			wsContent.Cells["D6"].Value = new DateTime(2015, 1, 3, 15, 15, 0);
			wsContent.Cells["D7"].Value = new DateTime(2015, 1, 3, 20, 15, 0);
			const int dataRow = 7;
			const string FORMATDATE = "m/d/yy h:mm;@";
			wsContent.Cells[2, 4, dataRow, 4].Style.Numberformat.Format = FORMATDATE;
			//var chartPressure = wsPressure.Drawings.AddChart("PressureChart", eChartType.Line);
			var chartPressure = wsPressure.Drawings.AddChart("PressureChart", eChartType.XYScatterLines);
			chartPressure.SetSize(1280, 1024);
			//var serie1 = (ExcelLineChartSerie)chartPressure.Series.Add("=Content!$A$2:$A$" + dataRow, "=Content!$D$2:$D$" + dataRow);
			var serie1 = (ExcelScatterChartSerie)chartPressure.Series.Add(wsContent.Cells[2, 1, dataRow, 1], wsContent.Cells[2, 4, dataRow, 4]);
			serie1.Header = wsContent.Cells[1, 1].Value.ToString();
			pck.Save();
		}
	}
