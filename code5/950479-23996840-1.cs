    double max = Double.MinValue; 
    double min = Double.MaxValue; 
    double leftLimit  = chart1.ChartAreas[0].AxisX.Minimum;
    double rightLimit = chart1.ChartAreas[0].AxisX.Maximum;
    for (int s = 0; s <= 1; s++)
    {
        foreach (DataPoint dp in chart1.Series[s].Points)
        {
            if (dp.XValue >= leftLimit && dp.XValue <= rightLimit)
            {
                min = Math.Min(min, dp.YValues[0]);
                max = Math.Max(max, dp.YValues[0]);
            }
        }
    }
    chart1.ChartAreas[0].AxisY.Maximum = max;
    chart1.ChartAreas[0].AxisY.Minimum = min;
