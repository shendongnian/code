    // cleanup before we start 
    chart1.ChartAreas.Clear();
    chart1.Series.Clear();
    // two areas one on top the other below
    chart1.ChartAreas.Add("area1");
    chart1.ChartAreas.Add("area2");
    // three series
    chart1.Series.Add("series1");
    chart1.Series.Add("series2");
    chart1.Series.Add("series3");
    // we assign  two series to the bottom area
    chart1.Series["series1"].ChartArea = "area1";
    chart1.Series["series2"].ChartArea = "area2";
    chart1.Series["series3"].ChartArea = "area2";
    // all series are of type spline
    chart1.Series["series1"].ChartType = SeriesChartType.Spline;
    chart1.Series["series2"].ChartType = SeriesChartType.Spline;
    chart1.Series["series3"].ChartType = SeriesChartType.Spline;
    // each has a spearate color
    chart1.Series["series1"].Color = Color.Red;
    chart1.Series["series2"].Color = Color.Blue;
    chart1.Series["series2"].Color = Color.Green;
    // now we add a few points
    chart1.Series["series1"].Points.AddXY(1, 100);
    chart1.Series["series1"].Points.AddXY(2, 400);
    chart1.Series["series1"].Points.AddXY(3, 200);
    chart1.Series["series1"].Points.AddXY(4, 300);
    chart1.Series["series2"].Points.AddXY(1, 120);
    chart1.Series["series2"].Points.AddXY(2, 420);
    chart1.Series["series2"].Points.AddXY(3, 290);
    chart1.Series["series2"].Points.AddXY(4, 390);
    chart1.Series["series3"].Points.AddXY(1, 220);
    chart1.Series["series3"].Points.AddXY(2, 320);
    chart1.Series["series3"].Points.AddXY(3, 690);
    chart1.Series["series3"].Points.AddXY(4, 190);
    // we can even paint a part of the spline curve in a different color
    chart1.Series["series3"].Points[1].Color = Color.HotPink;
    chart1.Series["series3"].Points[2].Color = Color.Orange;
