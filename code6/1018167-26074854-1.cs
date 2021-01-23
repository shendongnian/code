    var series = chart1.Series["Life"];
    series.Points.AddXY(0, 0);
    series.Points.AddXY(1, 1);
    series.Points.AddXY(2, 30);
    series.Points.AddXY(3, 20);
    series.Points.AddXY(4, 50);
    chart1.ChartAreas[0].AxisX.Minimum = 0;
