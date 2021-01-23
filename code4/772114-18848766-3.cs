    public SomeForm()
    {
        InitializeComponent();
            
        _keepRunning = true;
        _signalNewTask = new AutoResetEvent(false);
        _backgroundWorker = new Thread(WorkerLoop);
        _backgroundWorker.IsBackground = true;
        _backgroundWorker.Priority = ThreadPriority.BelowNormal;
        _backgroundWorker.Start();
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // set the running flag to false and signal the thread 
        // to wake it up
        _keepRunning = false;
        _signalNewTask.Set();
        
        // this will lock very shortly because the background
        // thread breaks when the flag is set
        _backgroundWorker.Join();
            
        base.OnFormClosed(e);
    }
    
