    hl = new HorizontalLineAnnotation();
    hl.AllowMoving = true;
    hl.LineColor = Color.OrangeRed;
    hl.LineWidth = 1;
    hl.X = 0;
    hl.Y = 0;  // or some other starting value..
    hl.Width = 100; 
    hl.ClipToChartArea = chart1.ChartAreas[0].Name;
    chart1.Annotations.Add(hl);
