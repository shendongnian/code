    Chart _chart = new Chart();
    TabPage2.Controls.Add(_chart);
    
    _chart.Location = new Point(469, 37);
    _chart.Name = "chart1";
    _chart.Size = new Size(448, 260);
    
    
    DataTable dt1 = new DataTable();
    dt1.Columns.Add("XVals", typeof(string));
    dt1.Columns.Add("YVals1", typeof(int));
    dt1.Columns.Add("YVals2", typeof(int));
    
    foreach (string c in "ABCDEF".ToCharArray()) {
    	dt1.Rows.Add(c, Convert.ToInt32(Math.Ceiling(VBMath.Rnd() * 20)), Convert.ToInt32(Math.Ceiling(VBMath.Rnd() * 20)));
    }
    
    ChartArea firstArea = _chart.ChartAreas.Add("First Area");
    Series seriesFirst = _chart.Series.Add("First Series");
    seriesFirst.ChartType = SeriesChartType.Column;
    
    ChartArea secondArea = _chart.ChartAreas.Add("Second Area");
    secondArea.BackColor = Color.Transparent;
    secondArea.AlignmentOrientation = AreaAlignmentOrientations.All;
    secondArea.AlignmentStyle = AreaAlignmentStyles.All;
    secondArea.AlignWithChartArea = firstArea.Name;
    secondArea.AxisY.LabelStyle.Enabled = false;
    secondArea.AxisX.LabelStyle.Enabled = false;
    
    Series seriesSecond = _chart.Series.Add("Second Series");
    seriesSecond.ChartType = SeriesChartType.Column;
    seriesSecond.ChartArea = secondArea.Name;
    
    _chart.DataSource = dt1;
    seriesFirst.Points.DataBind(dt1.DefaultView, "XVals", "YVals1", null);
    seriesSecond.Points.DataBind(dt1.DefaultView, "XVals", "YVals2", null);
    
    //Aligning the Y axis of the two chart areas
    //I am assuming here the x values for both series are similar and dont need to be altered
    //If using bar chart then x axis would be modifed not the y axis
    secondArea.AxisY = firstArea.AxisY;
    
    // *** Set locational values here for your first chart area***
    int heightAboveChartArea = 20;
    int heightBelowChartArea = 20;
    int axisLabelHeight = 40;
    int widthLeftOfChartArea = 20;
    int widthRightOfChartArea = 20;
    int heightPerBar = 20;
    int numberOfPoints = _chart.Series(0).Points.Count;
    
    // *** The following code should not normally be modified ***
    _chart.ChartAreas(0).Position.X = widthLeftOfChartArea / _chart.Width * 100;
    _chart.ChartAreas(0).Position.Width = 100 - (widthRightOfChartArea / _chart.Width * 100) - _chart.ChartAreas(0).Position.X;
    _chart.ChartAreas(0).Position.Y = (heightAboveChartArea / _chart.Height * 100);
    _chart.ChartAreas(0).Position.Height = 100 - (heightBelowChartArea / _chart.Height * 100) - _chart.ChartAreas(0).Position.Y;
