    List<int> list = new List<int>();
    SqlCommand cmd = new SqlCommand("select items from student_info", conn);
    SqlDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        list.Add(Convert.ToInt32(dr[0])); //getting all values in a List
    }
    int[] yValues = list.ToArray<int>(); //create your array here then use it
    string[] xValues = { "Coke", "Pepsi","Coffee"};
    
    Chart chart = new Chart();
    
    Series series = new Series("Default");
    series.ChartType = SeriesChartType.Column;
    
    chart.Series.Add(series);
    
    ChartArea chartArea = new ChartArea();
    Axis yAxis = new Axis(chartArea, AxisName.Y);
    Axis xAxis = new Axis(chartArea, AxisName.X);
    
    chart.Series["Default"].Points.DataBindXY(xValues, yValues);
    chart.ChartAreas.Add(chartArea);
    
    chart.Width = new Unit(500, System.Web.UI.WebControls.UnitType.Pixel);
    chart.Height = new Unit(200, System.Web.UI.WebControls.UnitType.Pixel);
    string filename = "C:\\check\\Chart.png";
    chart.SaveImage(filename, ChartImageFormat.Png);
    
    Panel1.Controls.Add(chart);
