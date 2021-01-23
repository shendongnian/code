    StripLine stripline = new StripLine();
    stripline.Interval = 0;
    stripline.IntervalOffset = average value of the y axis; eg:35
    stripline.StripWidth = 1;
    stripline.BackColor = Color.Blue;
    chart1.ChartAreas[ChartName].AxisY.StripLines.Add(stripline);
