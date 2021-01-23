                foreach (var item in lstSPCPrintID)
                {
                    string seriesname = String.Format("Position: {0}", Convert.ToString(item));
                    LineStackedSeries2D series = new LineStackedSeries2D();
                    series.ArgumentScaleType = ScaleType.Numerical;
                    series.DisplayName = seriesname;
                    series.SeriesAnimation = new Line2DUnwindAnimation();
                    var meas = from x in lstSPCChart
                               where x.intSPCPrintID == item
                               select new { x.dblSPCMeas };
                    var measdistinctcount = meas.GroupBy(x => x.dblSPCMeas).Select(group => new { Meas = group.Key, Count = group.Count() }).OrderBy(y => y.Meas);
                    foreach (var item2 in measdistinctcount)
                    {
                        series.Points.Add(new SeriesPoint(item2.Meas, item2.Count));
                    }
                    dxcSPCDiagram.Series.Add(series);
                    series.Animate();
                }
