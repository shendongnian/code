    private Thread _myThread = null;
    private ManualResetEvent _stopThread = new ManualResetEvent(false);
    public void StartLoop()
    {
        _myThread =  new Thread(() =>
        {
            while (!_stopThread.WaitOne(1))
            {
                lock (_myLocker)
                {
                    Event(this, new EventArgs()); //call event
                    _fooList[0] = 1; //do some writing on structure
                }
            }
        });
        _myThread.Start();
    }
    public void StopLoop()
    {
        stopThread.Set();
        _myThread.Join();
        // Why clear the structure? Rather re-init when restarting the threads
        //_fooList = null; //clear structure
    }
