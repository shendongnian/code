	[TestMethod]
	public void Chart_Secondary_Axis_Test()
	{
		//http://stackoverflow.com/questions/28540458/using-secondary-axis-for-chart-cause-x-axis-and-primary-y-axis-issue-excel
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			var wsContent = pck.Workbook.Worksheets.Add("Content");
			//Some data
			wsContent.Cells["A1"].Value = "A"; wsContent.Cells["B1"].Value = "B"; wsContent.Cells["C1"].Value = "C"; wsContent.Cells["D1"].Value = "D";
			wsContent.Cells["A2"].Value = 100; wsContent.Cells["A3"].Value = 400; wsContent.Cells["A4"].Value = 200; wsContent.Cells["A5"].Value = 300; wsContent.Cells["A6"].Value = 600; wsContent.Cells["A7"].Value = 500;
			wsContent.Cells["B2"].Value = 300; wsContent.Cells["B3"].Value = 200; wsContent.Cells["B4"].Value = 1000; wsContent.Cells["B5"].Value = 600; wsContent.Cells["B6"].Value = 500; wsContent.Cells["B7"].Value = 200;
			wsContent.Cells["D2"].Value = new DateTime(2015, 1, 1); wsContent.Cells["D3"].Value = new DateTime(2015, 1, 2); wsContent.Cells["D4"].Value = new DateTime(2015, 1, 3); wsContent.Cells["D5"].Value = new DateTime(2015, 1, 4); wsContent.Cells["D6"].Value = new DateTime(2015, 1, 5); wsContent.Cells["D7"].Value = new DateTime(2015, 1, 6);
			const int dataRow = 7;
			const string FORMATDATE = "m/d/yy";
			wsContent.Cells[2, 4, dataRow, 4].Style.Numberformat.Format = FORMATDATE;
			//Single Axis with intersection on the right
			var chart1 = wsContent.Drawings.AddChart("Chart1", eChartType.XYScatterLines);
			chart1.SetSize(600, 400);
			var serie1 = (ExcelScatterChartSerie)chart1.Series.Add(wsContent.Cells[2, 1, dataRow, 1], wsContent.Cells[2, 4, dataRow, 4]);
			serie1.Header = wsContent.Cells[1, 1].Value.ToString();
			chart1.YAxis.Crosses = eCrosses.Max;
			//Dual Axis
			var chart2a = wsContent.Drawings.AddChart("Chart2", eChartType.ColumnStacked);
			chart2a.SetSize(600, 400);
			chart2a.SetPosition(400, 0);
			var serie2a = chart2a.Series.Add(wsContent.Cells[2, 2, dataRow, 2], wsContent.Cells[2, 4, dataRow, 4]);
			serie2a.Header = wsContent.Cells[1, 2].Value.ToString();
			var chart2b = chart2a.PlotArea.ChartTypes.Add(eChartType.XYScatterLines);
			var serie2b = chart2b.Series.Add(wsContent.Cells[2, 1, dataRow, 1], wsContent.Cells[2, 4, dataRow, 4]);
			serie2b.Header = wsContent.Cells[1, 1].Value.ToString();
			chart2b.UseSecondaryAxis = true; //Flip the axes
			pck.Save();
		}
	}
