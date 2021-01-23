    public class TempWorker
        {
            private System.Timers.Timer _timer = new System.Timers.Timer();
            private Thread _thread = null;
    
            private object _workerStopRequestedLock = new object();
            private bool _workerStopRequested = false;
    
            private object _loopInProgressLock = new object();
            private bool _loopInProgress = false;
    
            bool LoopInProgress
            {
                get
                {
                    bool rez = true;
    
                    lock (_loopInProgressLock)
                        rez = _loopInProgress;
    
                    return rez;
                }
                set
                {
                    lock (_loopInProgressLock)
                        _loopInProgress = value;
                }
            }
    
            #region constructors
            public TempWorker()
            {
            }
            #endregion
    
            #region public methods
            public void StartWorker()
            {
                lock (_workerStopRequestedLock)
                {
                    this._workerStopRequested = false;
                }
                _thread = new Thread(new ThreadStart(StartTimerAndWork));
                _thread.Start();
            }
            public void StopWorker()
            {
                if (this._thread == null)
                    return;
    
                lock (_workerStopRequestedLock)
                    this._workerStopRequested = true;
    
                int iter = 0;
                while (LoopInProgress)
                {
                    Thread.Sleep(100);
    
                    iter++;
    
                    if (iter == 60)
                    {
                        _thread.Abort();
                    }
                }
    
                //if (!_thread.Join(60000))
                //    _thread.Abort();
    
            }
            #endregion
    
    
            #region private methods
    
            private void StartTimerAndWork()
            {
                this._timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                this._timer.Interval = 10000;//milliseconds
                this._timer.Enabled = true;
                this._timer.Start();
    
            }
    
    
            #endregion
    
    
            #region event handlers
            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (!LoopInProgress)
                {
                    lock (_workerStopRequestedLock)
                    {
                        if (this._workerStopRequested)
                        {
                            this._timer.Stop();
                            return;
                        }
                    }
    
                    DoWork();
    
                }
            }
    
            private void DoWork()
            {
                try
                {
                    this.LoopInProgress = true;
    
                    //DO WORK HERE
    
                }
                catch (Exception ex)
                {
                    //LOG EXCEPTION HERE
                }
                finally
                {
                    this.LoopInProgress = false;
                }
            }
            #endregion
    
        }
