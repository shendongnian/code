                chart1.Series.Clear();
    			chart1.ChartAreas[0].AxisY.CustomLabels.Clear();
    			chart1.Series.Add("FirstSeries");
    
    			// Set the type to line      
    			chart1.Series["FirstSeries"].ChartType = SeriesChartType.Line;
    			
    			// Color the line of the graph light green and give it a thickness of 3
    			chart1.Series[0].Color = Color.Red;
    			chart1.Series[0].BorderWidth = 1;
    
    			int minimum = 7, maximum = 300;
    			chart1.ChartAreas[0].AxisY.Minimum = minimum;
    			chart1.ChartAreas[0].AxisY.Maximum = maximum;
    			double logMin = Math.Log(chart1.ChartAreas[0].AxisY.Minimum, 10);
    
    			//If minimum starts from log(7) = 0.845 then take 1 which is equivalent to 100 in normal mode.
    			double ceilMin = Math.Ceiling(logMin);
    			double logMax = Math.Log(chart1.ChartAreas[0].AxisY.Maximum, 10);
    
    			chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
    			chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
    			chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
    			chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
    
    			double intervalOffset = ceilMin - logMin;
    			chart1.ChartAreas[0].AxisY.LabelStyle.IntervalOffset = intervalOffset;
    			chart1.ChartAreas[0].AxisY.MajorGrid.IntervalOffset = intervalOffset;
    			chart1.ChartAreas[0].AxisY.MinorGrid.IntervalOffset = intervalOffset;
    			chart1.ChartAreas[0].AxisY.MajorTickMark.IntervalOffset = intervalOffset;
    			chart1.ChartAreas[0].AxisY.MinorTickMark.IntervalOffset = intervalOffset;
    
    			//Setting intervals
    			chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 1;
    			chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
    			chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 1;
    			chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = 1;
    			chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 1;
    
    			for (int x = minimum; x <= maximum; x += 1)
    			{
    				chart1.Series[0].Points.Add(x, x);
    			}
    
    			//Adding custom labels for powers of 10 for example 1,10,100 
    			for (double x = minimum; x <= maximum; x+=1)
    			{
    				double logX = Math.Log10(x);
    				double floorX = Math.Floor(logX);
    				if (logX - floorX == 0)
    					chart1.ChartAreas[0].AxisY.CustomLabels.Add(logX-0.05, logX + 0.05, "" + Math.Pow(10, logX), 0, LabelMarkStyle.None);
    			}
    
    			//Adding minimum and maximum label. 0.05 factor is added by experiment.
    			chart1.ChartAreas[0].AxisY.CustomLabels.Add(logMin-0.05, logMin + 0.05, "" + chart1.ChartAreas[0].AxisY.Minimum, 0, LabelMarkStyle.None);
    			chart1.ChartAreas[0].AxisY.CustomLabels.Add(logMax-0.05, logMax+0.05, "" + chart1.ChartAreas[0].AxisY.Maximum, 0, LabelMarkStyle.None);
    
    			chart1.ChartAreas[0].AxisY.IsLogarithmic = true;
