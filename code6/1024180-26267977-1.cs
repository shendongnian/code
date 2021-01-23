    Chart chart1 = new Chart();
    
    chart1.Series.Add("series1");
    chart1.Series["series1"].Points.AddY(5);
    chart1.Series["series1"].Points.AddY(7);
    chart1.Series["series1"].Points.AddY(9);
    
    chart1.Series.Add("series2");
    chart1.Series["series2"].Points.AddY(1);
    chart1.Series["series2"].Points.AddY(3);
    chart1.Series["series2"].Points.AddY(2);
    
    TTestResult result = chart1.DataManipulator.Statistics.TTestPaired(0.2, 0.05, "series1", "series2");
