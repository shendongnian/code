     Dispatcher.Invoke(() =>
                              {
                                 chart1.Series[0].Points.Add(new SeriesPoint(i, rd.Next(40, 50)));
                                 chart2.Series[0].Points.Add(new SeriesPoint(i, rd.Next(40, 50)));
                                 chart3.Series[0].Points.Add(new SeriesPoint(i, rd.Next(40, 50)));
                                 chart1.Series[1].Points.Add(new SeriesPoint(i, rd.Next(60, 70)));
                                 chart2.Series[1].Points.Add(new SeriesPoint(i, rd.Next(60, 70)));
                                 chart3.Series[1].Points.Add(new SeriesPoint(i, rd.Next(60, 70)));
                                 chart1.Series[2].Points.Add(new SeriesPoint(i, rd.Next(70, 80)));
                                 chart2.Series[2].Points.Add(new SeriesPoint(i, rd.Next(70, 80)));
                                 chart3.Series[2].Points.Add(new SeriesPoint(i, rd.Next(70, 80)));
                                 i++;
                              });
