     public class  BackWorkerSingleton
        {
            private BackgroundWorker _backgroundWorker; 
            private static  readonly  object myLock = new object();
            private static  BackWorkerSingleton  _backWorkerSingleton =  new BackWorkerSingleton();
    
            private BackWorkerSingleton()
            {
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            }
    
            void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                // do your work here 
            }
            public void StartJob()
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
