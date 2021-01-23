    S1.ChartType = SeriesChartType.Point;
    for (int i=0; i < 2; i++)
    {
        DataPoint point = new DataPoint();
        point.SetValueXY(i, -0.5);
        if (i > 0) point.Color = Color.Transparent;
        S1.Points.Add(point);
    }
