	[TestMethod]
	public void Vertical_Bar_Chart()
	{
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			var ws = workbook.Worksheets.Add("newsheet");
			//Some data
			ws.Cells["A12"].Value = "wer";
			ws.Cells["A13"].Value = "sdf";
			ws.Cells["A14"].Value = "wer";
			ws.Cells["A15"].Value = "ghgh";
			ws.Cells["B12"].Value = 53;
			ws.Cells["B13"].Value = 36;
			ws.Cells["B14"].Value = 43;
			ws.Cells["B15"].Value = 86;
			//Create the chart
			var chart = (ExcelBarChart)ws.Drawings.AddChart("barChart", eChartType.ColumnClustered);
			chart.SetSize(300 ,300);
			chart.SetPosition(10,10);
			chart.Title.Text = "Clustered Bar Graph Report";
			//chart.Direction = eDirection.Column; // error: Property or indexer 'OfficeOpenXml.Drawing.Chart.ExcelBarChart.Direction' cannot be assigned to -- it is read only
			chart.Series.Add(ExcelRange.GetAddress(12, 2, 15, 2), ExcelRange.GetAddress(12, 1, 15, 1));
			package.Save();
		}
	}
