    private Queue<ManualResetEvent> _queuedThreads = new Queue<ManualResetEvent>();
    public void EnqueueThread()
    {
        var mre = new ManualResetEvent();
        var thread = new Thread(new ThreadStart(() =>
        {
            mre.WaitOne();
            // Continue
        });
       _queuedThreads.Enqueue(mre);
    }
    private void OnEvent()
    {
        var mre = _queuedThreads.Dequeue();
        mre.Set();   
    }
