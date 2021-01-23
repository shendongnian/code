    Series series = new Series("sample") { ChartType = SeriesChartType.Line, BorderWidth = 2, MarkerSize = 5, MarkerStyle = MarkerStyle.Square };
    series.Points.Add(new DataPoint(0, 1));
    series.Points.Add(new DataPoint(1, 1));
    series.Points.Add(new DataPoint(1.5, double.NaN) { IsEmpty = true });
    series.Points.Add(new DataPoint(2, 1));
    series.Points.Add(new DataPoint(3, 2));
    chart.Series.Add(series);
