    private void Main(byte[] rec_arr)
    {
        var series1 = new Series("series1");
        series1 .ChartType = SeriesChartType.Line;
        series1 .MarkerStyle = MarkerStyle.Circle;
        series1 .MarkerSize = 3;
        series1 .YAxisType = AxisType.Primary;
        series1 .Color = Color.Navy;
        var series2 = new Series("series2");
        series2 .ChartType = SeriesChartType.Line;
        series2 .MarkerStyle = MarkerStyle.Triangle;
        series2 .MarkerSize = 3;
        series2 .YAxisType = AxisType.Primary;
        series2 .Color = Color.Crimson;
        foreach (var series in Chart1.Series)
        {
            series.Points.Clear();
        }
        double interval1 = 0;
        double interval2 = File_Details.time / (double)124;
        int Offset2 = 502;
        int Offset3 = 750;
        float data1, data2;
        if (File_Details.time == 0)
        {
            Label_Error_Graph.Visible = true;
            Chart1.ChartAreas[0].AxisX.Maximum = 0;
            Chart1.ChartAreas[0].AxisX.Minimum = 0;
            Chart1.Series[0].Points.Add(0);
            Chart1.Series[1].Points.Add(0);
        }
        else
        {
            Label_Error_Graph.Visible = false;
        }
        for (interval1 = 0; interval1 < File_Details.time; interval1 += interval2)
        {
            data1 = DecodeSingle(rec_arr, Offset3);
            if (Chart1.Series.IndexOf("series1") == -1)
            {
                Chart1.Series.Add(series1);
            }
            Offset3 = Offset3 + 2;
            if (data1 < 300)
            {
                Chart1.Series[0].Points.AddXY(interval1, supply);
            }
            else
            {
                Chart1.Series[0].Points.AddXY(interval1, 300);
            }
        }
        for (interval1 = 0; interval1 < File_Details.time; interval1 += interval2)
        {
            data2 = DecodeSingle(rec_arr, Offset2) / (float)100;
            if (Chart1.Series.IndexOf("series2") == -1)
            {
                Chart1.Series.Add(series2);
            }
            Offset2 = Offset2 + 2;
            if (data2 < 150)
            {
                Chart1.Series[1].Points.AddXY(interval1, data2);
            }
            else
            {
                Chart1.Series[1].Points.AddXY(interval1, 150);
            }
        }
    }
