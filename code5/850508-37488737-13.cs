    hl = new HorizontalLineAnnotation();
    hl.AllowMoving = true;
    hl.LineColor = Color.OrangeRed;
    hl.LineWidth = 1;
    hl.AnchorDataPoint = S1.Points[1];
    hl.X = 0;
    hl.Y = 0;         // or some other starting value..
    hl.Width = 100;   // percent of chart..
    hl.ClipToChartArea = chart1.ChartAreas[0].Name;  // ..but clipped
    chart1.Annotations.Add(hl);
