    double temp = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(Convert.ToDouble(ce.sChannelFrequency) * 1000);
    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1))) {
        SizeF size = graphics.MeasureString(freq.Text, new Font("eurostile", 13, FontStyle.Bold, GraphicsUnit.Pixel));
        temp -= (size.Width/2+10);
    }
    if (temp < 0) temp = 0;
    temp = chart1.ChartAreas[0].AxisX.PixelPositionToValue(temp);
    freq.X = chart1.ChartAreas[0].AxisX.ValueToPosition(temp);
