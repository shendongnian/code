    var IETable = (dt as System.ComponentModel.IListSource).GetList();
    chChart.DataBindCrossTable(IETable, "Number","","Start Time,StopTime","");
                     
                      foreach (Series sr in chChart.Series)
                      {
    
                          sr.ChartType = SeriesChartType.RangeBar;
                          sr.XValueType = ChartValueType.String;
                          foreach (DataPoint p in sr.Points)
                          {
                              int dpIndex=0;
                              // foreach unique x axis value, increment dpIndex
	                          //ToDoCode
	 
	                         //aligning the datapoint's X axis value in the middle
    
                              p.XValue = dpIndex + 0.5;
                              
                          }
    
                      }
