    using System.Windows.Forms.DataVisualization.Charting;
    //..
    private void button2_Click(object sender, EventArgs e)
    {
        chart1.Legends.Clear();
        chart1.Series[0].ChartType = SeriesChartType.FastLine;
        chart1.Series[0].Color = Color.Red;
        chart1.Series[0].BorderWidth = 3;
        chart1.Series[0].Points.AddXY(130, 15);
        chart1.Series[0].Points.AddXY(150, 12);
        chart1.Series[0].Points.AddXY(160, 18);
    }
