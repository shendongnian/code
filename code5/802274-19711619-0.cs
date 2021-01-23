    foreach (Series s in chart.Series)
			{
				s.ChartType = SeriesChartType.Column;
				s.Name = s.Points.First().LegendText;
				chart.Legends.Add(GetLegend(s.Name));
			}
