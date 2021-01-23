                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Series series = new Series();
                        series.Points.AddXY(dr["Date"], dr["Shipments"]);
                        series.ChartType = yourChartTypeList[i];
                        i++;
                        Chart1.Series.Add(series);
                    }
                    
