    private void chartTimer_Tick(object sender, EventArgs e)
    {
        foreach (DataPoint item in chart1.Series[1].Points)
        {
            item.Label = "";
        }
        chart1.Series[1].LegendText = chart1.Series[1].Name = str + " KB/s";
        DataPoint Point = chart1.Series[1].Points[chart1.Series[1].Points.Count - 1];
        Point.Label = chart1.Series[1].Name;
    }
