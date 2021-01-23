    Excel.ChartObjects xlCharts =　(Excel.ChartObjects)newWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject chart = (Excel.ChartObject)xlCharts.Add(10, 80, 300,250);             
    Excel.Chart chartPage = chart.Chart;
    Excel.Range chartRange = newWorkSheet.get_Range("A1:A5");
    chartPage.SetSourceData(chartRange, Type.Missing);
    chartPage.ChartType = Excel.XlChartType.xlLine;
    chartPage.HasLegend = false;
    Series series = (Series)(chart.Chart.SeriesCollection(1));
    series.XValues = newWorkSheet.get_Range("B1:B5");
