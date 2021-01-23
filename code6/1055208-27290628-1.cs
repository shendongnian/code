    Series S1 = chart1.Series[0];
    Series S2 = chart1.Series[1];
    S1.ChartType = SeriesChartType.Line;
    S2.ChartType = SeriesChartType.Line;
    S1.Color = Color.Red;
    S2.Color = Color.Green;
    S1.XValueType = ChartValueType.Time;
    S2.XValueType = ChartValueType.Time;
    for (int d = 100; d < 200; d++)
    {
        DateTime dt = DateTime.Now.AddMinutes(d);
        S1.Points.AddXY(dt, 100 + R.Next(100));
    }
    for (int d = 150; d < 300; d++)
    {
        DateTime dt = DateTime.Now.AddMinutes(d);
        S2.Points.AddXY(dt, 200 + R.Next(100));
    }
