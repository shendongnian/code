    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;    
    chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
    chart1.Series[0].MarkerBorderColor = System.Drawing.Color.Black;
    chart1.Series[0].MarkerColor = System.Drawing.Color.Red;
    chart1.Series[0].Points.AddXY(1, 1);
    chart1.Series[0].Points.AddXY(2, 4);
    chart1.Series[0].Points.AddXY(3, 9);
    chart1.Series[0].Points.AddXY(4, 6);
    foreach (DataPoint dp in chart1.Series[0].Points)
    {
        switch ((int)dp.XValue)
        {
            case 1: dp.AxisLabel = "Frogs"; break;
            case 2: dp.AxisLabel = "Hogs"; break;
            case 3: dp.AxisLabel = "Bogs"; break;
            case 4: dp.AxisLabel = "Slogs"; break;
        }
    }
