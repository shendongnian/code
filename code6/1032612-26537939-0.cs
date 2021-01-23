    var timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(0.1d),
                };
    var pointsRemaining = 50;
    var r = new Random();
    timer.Tick += (sender, args) =>
                  {
                      if (--pointsRemaining == 0)
                          timer.Stop();
                      chart1.Series["test1"].Points.AddXY(r.Next(0,10), r.Next(0,10));
                      chart1.Series["test2"].Points.AddXY(r.Next(0,10), r.Next(0,10));
                  };
    timer.Start();
