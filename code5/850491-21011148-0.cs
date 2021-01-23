    private void UpdateChart()
    {
        float y = 5;    // YValue of the straight line
        List<DataPoint> list = new List<DataPoint>() {
            new DataPoint(0, 0),
            new DataPoint(1, 10),
            new DataPoint(2, 15),
            new DataPoint(3, 2),
            new DataPoint(4, 10),
            new DataPoint(5, 8),
        };
        int count = list.Count - 2;
        for (int i = 0; i < count; i++)
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
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        for (int i = 0; i < list.Count; i++)
        {
            double xx = list[i].XValue;
            double yy = list[i].YValues[0];
            if (yy > y)
            {
                chart1.Series[0].Points.AddXY(xx, 5, yy);
            }
            else
            {
                chart1.Series[0].Points.AddXY(xx, yy, yy);
            }
        }
    }
