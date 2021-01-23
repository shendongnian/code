    private void LoadGraph()
    {
        seriesBps = new Series("bps");
        seriesBps.Color = Color.Blue;
        seriesBps.ChartType = SeriesChartType.Spline;
        seriesBps.BorderWidth = 2;
        chart1.Series.Add(seriesBps);
        seriesPps = new Series("pps");
        seriesPps.Color = Color.Blue;
        seriesPps.ChartType = SeriesChartType.Spline;
        seriesPps.BorderWidth = 2;
        chart1.Series.Add(seriesPps);
        // set up axes as you already do
    }
