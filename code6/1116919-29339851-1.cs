    while (myReader.Read())
    {
    //Parameters (Seriesname, x-axis data & y-axis data)
    this.chart.Series["Series"].Points.AddXY(myReader["Finance"], myReader["GWU"]);
    
    }
    
    if(chart.ChartAreas.Count > 0)
    {
    chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
    chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
    chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
    }
    
    
    if(chart.Series["series1"].Points.Count > 5)
    {
    chart.Series["series1"].Points[0].Color = Color.Green;
    chart.Series["series1"].Points[1].Color = Color.Red;
    chart.Series["series1"].Points[2].Color = Color.PowderBlue;
    chart.Series["series1"].Points[3].Color = Color.Peru;
    chart.Series["series1"].Points[4].Color = Color.Pink;
    chart.Series["series1"].Points[5].Color = Color.Purple;
    }
    
