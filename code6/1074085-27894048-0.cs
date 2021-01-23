    private static object _lock = new object();
    private static int _queuedCount = 0;
    
    public Map()
    {
      InitializeComponent();
    
      _worker = new BackgroundWorker();
      _worker.DoWork += _worker_DoWork;
      _worker.ProgressChanged += _worker_ProgressChanged;
      _worker.WorkerReportsProgress = true;
    }
    
    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
        _frameCount = _frames.FrameCount();
        // For this specific example, _frameCount may be around 30000-40000
        for (var i = 0; i < _frameCount; i++)
        {
          var f = _frames.Frame(i + 1);
          lock(_lock)
          {
              _queuedCount++;
          }
          _worker.ReportProgress(i, f);
          Thread.Sleep(_tickCount);
          _suspend.WaitOne(); // Used to Pause the playback
        }
    }
    void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (_queuedCount > 1)
          //now queue is building up
     
      this.Refresh();
      lock(_lock)
      {
          _queuedCount--;
      }
    }
