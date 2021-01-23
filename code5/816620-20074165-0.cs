            using (var ch = new Chart())
            {
                ch.ChartAreas.Add(new ChartArea());
                Series series = new Series("Connections");
                series.ChartType = SeriesChartType.Line;
                ch.Series.Add(series);
                ChartArea chartArea = new ChartArea();
                ch.ChartAreas.Add(chartArea);
                ch.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                Axis x = new Axis(chartArea, AxisName.X);
                x.LineWidth = 90;
                Axis y = new Axis(chartArea, AxisName.Y);
                List<DateTime> dates = new List<DateTime>();
                List<double> values = new List<double>();
                using (var tf = TeaFile<IntData>.OpenRead(DataRecorder.GetFileName("Connections")))
                {
                    foreach (IntData item in tf.Items)
                    {
                        dates.Add(item.Time);
                        values.Add(item.Value);
                    }
                }
                ch.Height = 1500;
                ch.Width = 600;
                ch.Series["Connections"].Points.DataBindXY(dates, values);
                ch.SaveImage("C:\\mypic.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
