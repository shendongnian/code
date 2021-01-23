        ChartArea CA = chart1.ChartAreas[0];  // pick the right ChartArea !
        // factors to convert values to pixels
        double xFactor = 1.0;      // use your numbers!
        double yFactor = 1.0;      // use your numbers!
        // the vertical line
        VA = new VerticalLineAnnotation();
        VA.AllowMoving = true;
        VA.IsInfinitive = true;
        VA.ClipToChartArea = CA.Name;
        VA.Name = "myLine";
        VA.LineColor = Color.Red;
        VA.LineWidth = 3;            // use your numbers!
        VA.X = 11 * xFactor;         // use your numbers!
        // the rectangle
        RA = new RectangleAnnotation();
        RA.IsSizeAlwaysRelative = false;
        RA.Width = 1 * xFactor;         // use your numbers!
        RA.Height = 0.5 * yFactor;      // use your numbers!
        VA.Name = "myRect";
        RA.LineColor = Color.Red;
        RA.BackColor = Color.Red;
        RA.AxisY = CA.AxisY;
        RA.Y = -RA.Height;
        RA.X = VA.X - RA.LineWidth / 2;
        // now we add the two annotations:
        chart1.Annotations.Add(VA);
        chart1.Annotations.Add(RA);
