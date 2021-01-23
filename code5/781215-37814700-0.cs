    ((LineSeries)GradePointAverage.Series[0]).IndependentAxis = new LinearAxis
                                                  {
                                                      Minimum = 1,
                                                      Maximum = 6,
                                                      Orientation = AxisOrientation.X,
                                                      Interval = 1
                                                  };
    ((LineSeries)GradePointAverage.Series[0]).DependentAxis = new LinearAxis
                                                      {
                                                          Orientation = AxisOrientation.Y,
                                                          ShowGridLines = true
                                                      };
