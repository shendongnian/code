      Series S1 = chart1.Series[0];
      S1.ChartType = SeriesChartType.Column;
      for (int d = 0; d <= 100; d ++)
      {
          S1.Points.AddXY(d, 100 + d * 3);
          S1.Points[d].Color = Color.FromArgb(255, d, d * 2, 255 - d * 2);
      }
