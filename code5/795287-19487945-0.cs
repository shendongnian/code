    int[] val = new int[3];
	chart1.Series.Add(series);
	for (int i = 0; i < 3; i++)
	{
		val[i] = rand.Next(30000, 80000);
		series.Points.AddXY(i, val[i]);
	}
			
	Series series2 = new Series();
	series2.ChartType = SeriesChartType.RangeBar;
	chart2.Series.Add(series2);
	for (int i = 2; i > -1; i--)
	{
		series2.Points.AddXY(i, val[-i+2]);
	}
