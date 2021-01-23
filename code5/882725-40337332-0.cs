    foreach (DataColumn dc in dtChartDataSource.Columns)
    {
       //a series to the chart
     if (chart.Series.FindByName(dc.ColumnName) == null)
     {
          series = dc.ColumnName;
          chart.Series.Add(series);
          chart.Series[series].ChartType = SeriesChartType.Column;
    
        foreach (DataRow dr in dtChartDataSource.Rows)
        {
            double dataPoint = 0;
            double.TryParse(dr[dc.ColumnName].ToString(), out dataPoint);
     
            Yourchart.Series[seriesName].Points.AddXY("customStringsOnAxis", dataPoints);
        }
     }
    }
