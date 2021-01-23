    using System.Windows.Forms.DataVisualization.Charting;
    using System.Globalization;
    private void setChart(int Year)
    {
        bool showAsDate = true;
        var s = new Series(year.ToString() );
        s.ChartType = SeriesChartType.Column;
        var d = new DateTime(year, 01, 01);
        int weekday = (int)d.DayOfWeek;
        int maxDays = new DateTime(year, 12, 31).DayOfYear;
        Random R = new Random();
        for (int i = 0; i < maxDays ; i++)
        {
            s.Points.AddXY(d.AddDays(i), R.Next(100) - 50);
        }
        chart1.Series[0].Points.Clear();
        chart1.Series.Clear();
        chart1.Series.Add(s);
        if (showAsDate )
        {
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 7;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
        }
        else
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            for (int i = 0; i < maxDays ; i++)
            {
               chart1.Series[0].Points[i].AxisLabel = 
                      cal.GetWeekOfYear(d.AddDays(i), 
                      dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();
               chart1.ChartAreas[0].AxisX.IntervalOffset = 2 - weekday;
            }
        }
