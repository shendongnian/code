    var IETable = (dt as System.ComponentModel.IListSource).GetList();
    chChart.DataBindCrossTable(IETable, "Number","","Start Time,StopTime","");
                     
                      foreach (Series sr in chChart.Series)
                      {
    
                          sr.ChartType = SeriesChartType.RangeBar;
                          sr.XValueType = ChartValueType.String;
                          foreach (DataPoint p in sr.Points)
                          {
                              int dpIndex=0;
                              foreach (string x in vn)
                              {
                                  if (x == sr.Name)
                                      break;
                                  dpIndex++;
                                   
                              }
    
                              p.XValue = dpIndex + 0.5;
                              p["DrawingStyle"] = "Cylinder";
                              p["PointWidth"] = "0.2";
                              p["BarLabelStyle"] = "Center";
                          }
    
                      }
