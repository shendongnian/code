    public PlotModel DataPlot { get; set; }
    private double _xValue = 1;
    public MainViewModel()
    {
     DataPlot = new PlotModel();
     DataPlot.Series.Add(new LineSeries());
     var dispatcherTimer = new DispatcherTimer();
     dispatcherTimer.Tick += dispatcherTimer_Tick;
     dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
     dispatcherTimer.Start(); 
    }
     private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
     Dispatcher.CurrentDispatcher.Invoke(() =>
     {
      (DataPlot.Series[0] as LineSeries).Points.Add(new DataPoint(_xValue, Math.Sqrt(_xValue)));
      DataPlot.InvalidatePlot(true);
      _xValue ++;
     });
    }
