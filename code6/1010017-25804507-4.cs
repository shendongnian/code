    CA = chart1.ChartAreas[0];  // pick the right ChartArea..
    S1 = chart1.Series[0];      // ..and Series!
    // factors to convert values to pixels
    double xFactor = 1.0;         // use your numbers!
    double yFactor = 1.0;         // use your numbers!
    // the vertical line
    VA = new VerticalLineAnnotation();
    VA.AxisX = CA.AxisX;
    VA.AllowMoving = true;
    VA.IsInfinitive = true;
    VA.ClipToChartArea = CA.Name;
    VA.Name = "myLine";
    VA.LineColor = Color.Red;
    VA.LineWidth = 2;         // use your numbers!
    VA.X = 1; 
    // the rectangle
    RA = new RectangleAnnotation();
    RA.AxisX = CA.AxisX;
    RA.IsSizeAlwaysRelative = false;
    RA.Width = 6 * xFactor;         // use your numbers!
    RA.Height = 3 * yFactor;        // use your numbers!
    VA.Name = "myRect";
    RA.LineColor = Color.Red;
    RA.BackColor = Color.Red;
    RA.AxisY = CA.AxisY;
    RA.Y = -RA.Height ;
    RA.X = VA.X - RA.LineWidth / 2;
    chart1.Annotations.Add(VA);
    chart1.Annotations.Add(RA);
