    private void DailyTimeEntryDisplay_Load(object sender, EventArgs e)
    {
        chart1.Palette = ChartColorPalette.None;
        chart1.PaletteCustomColors = new Color[] { Color.LightGreen };
        //DateTime minDate = new DateTime(1900, 1, 1);
        //chart1.ChartAreas[0].AxisY.Minimum = minDate.ToOADate();
        //chart1.ChartAreas[0].AxisY.Maximum = minDate.AddDays(1).ToOADate();
    
        chart1.ChartAreas[0].AxisY.Interval = 1;
        chart1.ChartAreas[0].AxisY.LabelStyle.Format = "HH:mm";
        chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 1;
        chart1.ChartAreas[0].AxisY.LabelStyle.Angle = 45;
        chart1.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
        chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
        chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeColumn; // "RangeColumn" instead of "RangeBar"
        chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
        chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time; // "Time" instead of "DateTime"
        DisplayData();
    }
