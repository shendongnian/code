    string info = "Value: " + "#VAL{N2}" + "\n" + "Average: " + "#AVG{N2}" + "\n" + "Minimum: " + "#MIN{N2}" + "\n" + "Maximum: " + "#MAX{N2}" + "\n"
                + "First: " + "#FIRST{N2}" + "\n" + "Last: " + "#LAST{N2}";
    Chart1.Series[0].ToolTip = "Series name..." + "\n" + info;
    Chart1.Series[1].ToolTip = "Series name2..." + "\n" + info;
    Chart1.Series[2].ToolTip = "Series name3..." + "\n" + info;
    private void Chart1_MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult result = Chart1.HitTest(e.X, e.Y);
        System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
        Chart1.ChartAreas[0].CursorX.Interval = 0;
        Chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
        Chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);
    }
