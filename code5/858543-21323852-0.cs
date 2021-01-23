    private void Form1_Load(object sender, EventArgs e)
    {
        chart1.Series.Clear();
        chart1.Series.Add(new Series { ChartType = SeriesChartType.Area, Color = Color.FromArgb(100, Color.Red) });
        chart1.Series.Add(new Series { ChartType = SeriesChartType.Area, Color = Color.FromArgb(100, Color.Blue) });
        chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
        
        Random rnd = new Random();
        
        int y0 = 50;
        int y1 = 50;
        
        for (int i = 0; i <= 100; i++)
        {
            y0 += rnd.Next(20) - 8;
            y1 += rnd.Next(20) - 8;
            chart1.Series[0].Points.AddXY(i, y0);
            chart1.Series[1].Points.AddXY(i, y1);
        }
    }
