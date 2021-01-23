    private void UpdateChart(float straight_line, List<DataPoint> curve)
    {
        float y = straight_line;    // YValue of the straight line
        var list = curve.ToList();  // Clone the curve
        int count = list.Count - 2;
        for (int i = 0; i < count; i++)  // Calculate intersection point between the straight line and a line between (x0,y0) and (x1,y1) 
        {
            double x0 = list[i + 0].XValue;
            double y0 = list[i + 0].YValues[0];
            double x1 = list[i + 1].XValue;
            double y1 = list[i + 1].YValues[0];
            if ((y0 > y && y1 < y) || (y0 < y && y1 > y))
            {
                double x = (y - y0) * (x1 - x0) / (y1 - y0) + x0;
                list.Add(new DataPoint(x, y));
            }
        }
        list.Sort((a, b) => Math.Sign(a.XValue - b.XValue));
        chart1.Series[0].Points.Clear();
        chart1.Series[0].ChartType = SeriesChartType.Range;
        chart1.Series[0].Color = Color.Red;
        chart1.Series[0].BorderColor = Color.Cyan;
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        for (int i = 0; i < list.Count; i++)
        {
            double xx = list[i].XValue;
            double yy = list[i].YValues[0];
            if (yy > y)
            {
                chart1.Series[0].Points.AddXY(xx, y, yy);
            }
            else
            {
                chart1.Series[0].Points.AddXY(xx, yy, yy);
            }
        }
        chart1.ChartAreas[0].AxisY.StripLines.Add(new StripLine { IntervalOffset = y, Interval = 0, BorderColor = Color.Orange, BorderWidth = 2 });
    }
