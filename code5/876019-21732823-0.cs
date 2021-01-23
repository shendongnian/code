                Series s = oneSecondChart.Series.Add(name); 
                s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            for (int i = 0; i < data.Length; i++) {
                oneSecondChart.Series[name].Points.AddY(data[i]);
            }
