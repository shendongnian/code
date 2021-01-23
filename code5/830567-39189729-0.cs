    Series s = chart1.Series.Add("Pie");
    s.ChartType = SeriesChartType.Pie;
    s.IsValueShownAsLabel = true;
    s.Points.AddXY(0, 12);
    s.Points.AddXY(1, 22);
    s.Points.AddXY(2, 42);
    s.Points[0].LegendText = "wo";
    s.Points[1].LegendText = "wa";
    s.Points[2].LegendText = "wi";
