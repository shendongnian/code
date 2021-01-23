    for (int i = 1; i <= 3; i++)
    {
        // add a series to the chart
        string item = "boo" + i.ToString();
        chart1.Series.Add(item);
        chart1.Series[item].ChartType = SeriesChartType.StackedColumn;
        for (int a = 1; a <= 5; a++)
        {
            // add 5 points to the current series 
            chart1.Series[item].Points.AddXY(a, 100.0);
        }
    }
