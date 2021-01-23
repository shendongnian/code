    ManualResetEvent _busy = new ManualResetEvent(true);
    public BackgroundWorker mainBackGroundWorker;
    
    public void PauseWorker()
    {
       if(mainBackGroundWorker.IsBusy)
       {
            _busy.Reset(); 
       }
    }
    
    public void ContinueWorker()
    {
        _busy.Set();
    }
