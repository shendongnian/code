    Series s1 = chart1.Series.Add("S1");
    s2.ChartType = SeriesChartType.Area;
    ChartArea ca = chart1.ChartAreas[0];
    ca.AxisX.Minimum = 0;
    AddArea(chart1, s2, 12, 53, Color.SlateBlue);
    AddArea(chart1, s2, 32, 63, Color.Firebrick);
    AddArea(chart1, s2, 22, 23, Color.SlateBlue);
    AddArea(chart1, s2, 62, 33, Color.Goldenrod);
    AddArea(chart1, s2, 12, 33, Color.PaleVioletRed);
