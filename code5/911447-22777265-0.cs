    // Add chart.
    var charts = worksheet.ChartObjects() as
	    Microsoft.Office.Interop.Excel.ChartObjects;
	var chartObject = charts.Add(60, 10, 300, 300) as
	    Microsoft.Office.Interop.Excel.ChartObject;
	var chart = chartObject.Chart;
	// Set chart range.
	var range = worksheet.get_Range(topLeft, bottomRight);
	chart.SetSourceData(range);
	// Set chart properties.
	chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
	chart.ChartWizard(Source: range,
	    Title: graphTitle,
	    CategoryTitle: xAxis,
	    ValueTitle: yAxis);
