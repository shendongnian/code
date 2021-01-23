    private void changeYScala(object chart)
    {
        double max = Double.MinValue;
        double min = Double.MaxValue;
        Chart tmpChart = (Chart)chart;
        double leftLimit = tmpChart.ChartAreas[0].AxisX.Minimum;
        double rightLimit = tmpChart.ChartAreas[0].AxisX.Maximum;
        for (int s = 0; s < tmpChart.Series.Count(); s++)
        {
            foreach (DataPoint dp in tmpChart.Series[s].Points)
            {
                if (dp.XValue >= leftLimit && dp.XValue <= rightLimit)
                {
                    min = Math.Min(min, dp.YValues[0]);
                    max = Math.Max(max, dp.YValues[0]);
                }
            }
        }
        //tmpChart.ChartAreas[0].AxisY.Maximum = max;
        tmpChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling((max / 10)) * 10);
        tmpChart.ChartAreas[0].AxisY.Minimum = (Math.Floor((min / 10)) * 10);
        //tmpChart.ChartAreas[0].AxisY.Minimum = min;
    }
