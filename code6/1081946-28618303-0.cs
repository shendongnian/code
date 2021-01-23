    chart.UpdateLayout();
    chart.Arrange(new Rect(new System.Windows.Size(chart.ActualWidth, chart.ActualHeight)));
    chart.UpdateLayout();
    chartx.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity)); // from charttoimageprocess(...)
    int chartW = (int)Math.Round(chartx.ActualWidth);
    int chartH = (int)Math.Round(chartx.ActualHeight);
