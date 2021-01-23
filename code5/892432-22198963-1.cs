      public class  BackWorkerSingleton
    {
        private BackgroundWorker _backgroundWorker; 
        private static  readonly  object myLock = new object();
        private static  BackWorkerSingleton  _backWorkerSingleton =  new BackWorkerSingleton();
        
        public delegate  void  ReportProgressEventHandler(object sender,MyEventsArgs e);
        public event ReportProgressEventHandler ReportProgress = delegate{ };  
        private BackWorkerSingleton()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);
            
        }
        void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ReportProgress( this, new MyEventsArgs(){Progress = e.ProgressPercentage});
        }
        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // do your work here 
        }
        public void StartTheJob()
        {
            _backgroundWorker.RunWorkerAsync();
        }
        public static  BackWorkerSingleton Worker
        {
            get
            {
                lock (myLock)
                {
                    if (_backWorkerSingleton == null)
                    {
                        _backWorkerSingleton = new BackWorkerSingleton();
                    }
                }
                return _backWorkerSingleton;  
            }
        }
    }
    class MyEventsArgs:EventArgs
    {
        public int Progress { get; set;  }
    }
