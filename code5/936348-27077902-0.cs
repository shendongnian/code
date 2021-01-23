    ChartArea A1 = chart1.ChartAreas["yourChartAreaByNameOrNumber"];
    A1.AxisX.ScrollBar.Size = 12;
    // show either just the center scroll button..
    A2.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
    // .. or include the left and right buttons:
    A1.AxisX.ScrollBar.ButtonStyle = 
        ScrollBarButtonStyles.All ^ ScrollBarButtonStyles.ResetZoom;
    // looks better inside, but ymmv
    A1.AxisX.ScrollBar.IsPositionedInside = true;
    A1.AxisX.ScrollBar.Enabled = true;
    A1.AxisX.ScaleView.Size = 100;  // number (!) of data points visible
