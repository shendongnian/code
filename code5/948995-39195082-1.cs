    int AddArea(Chart chart, Series s, double x, double y, Color color)
    {
        ChartArea ca = chart.ChartAreas[s.ChartArea];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        if (s.Points.Count == 0) s.Points.AddXY(ax.Minimum, ay.Minimum);
        DataPoint dp0 = s.Points.Last();
        int p1 = s.Points.AddXY(dp0.XValue, y);
        s.Points.AddXY(dp0.XValue + x, y);
        s.Points.Last().Color = color;
        s.Points.AddXY(dp0.XValue + x, ay.Minimum);
        dp0.Color = color;
        s.Points.Last().Color = color;
        return p1;
    }
