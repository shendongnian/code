    private readonly BackgroundWorker worker
        = new BackgroundWorker { WorkerReportsProgress = true };
    public MainWindow()
    {
        InitializeComponent();
        worker.DoWork += worker_DoWork;
        worker.ProgressChanged += worker_ProgressChanged;
    }
    private void worker_DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        // Do some long process, break it up into a loop so you can periodically
        //  call worker.ReportProgress()
        worker.ReportProgress(i);  // Pass back some meaningful value
    }
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        prgBar.Value = Math.Min(e.ProgressPercentage, 100);
    }
