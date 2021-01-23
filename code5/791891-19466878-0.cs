    public PlotModel MyPlotModel { get; set; }
    
    public your_window_name()
    {
	    InitializeComponent();
	    var linesSeries = new LineSeries("Random");
	    Random rand = new Random();
	    int x = 0;
	    this.MyPlotModel = new PlotModel();
	    this.MyPlotModel.Series.Add(linesSeries);
	    DataContext = this;
	    var bg_worker = new BackgroundWorker {WorkerSupportsCancellation = true};
	    bg_worker.DoWork += (s, e) =>
		{
			while (!bg_worker.CancellationPending)
			{
				linesSeries.Points.Add(new DataPoint(x, rand.Next(0, 10)));
				x += 1;
				MyPlotModel.RefreshPlot(true);
				Thread.Sleep(100);
			}
		};
	    bg_worker.RunWorkerAsync();
	    this.Closed += (s, e) => bg_worker.CancelAsync();
    }
    
