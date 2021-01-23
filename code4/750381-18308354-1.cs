    double valueMinimum = this.chartReport.ChartAreas[0].AxisY.Minimum; 
    double valueMaximum = this.chartReport.ChartAreas[0].AxisY.Maximum; 
    double labelInterval = this.chartReport.ChartAreas[0].AxisY.LabelStyle.Interval;
    
    for (double increment = valueMinimum; increment <= valueMaximum; increment += labelInterval)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(increment);
                    chartReport.ChartAreas[0].AxisY.CustomLabels.Add(
                        increment - labelInterval / 2, 
                        increment + labelInterval / 2, String.Format ("{0}h:{1}m:{2}s",
                        ts.Days * 24 + ts.Hours, ts.Minutes, ts.Seconds)
                        );
                }
