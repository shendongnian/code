    public TestView()
    {
        InitializeComponent();
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.ProgressChanged += ProgressChanged;
        backgroundWorker.DoWork += DoWork;
    }
