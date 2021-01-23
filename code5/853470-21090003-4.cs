    private Thread _thread;
    private ManualResetEvent _started = new ManualResetEvent(false);
    private ManualResetEvent _terminating = new ManualResetEvent(false);
    private ManualResetEvent _terminated = new ManualResetEvent(false);
    public void InitializeComponent()
    {
        _thread = new Thread(() => totalDistance());
        _thread.Start();
        // wait until the thread is started.
        _started.WaitOne();
    }
    private void totalDistance()
    {
        // do some initialization stuff..
        // Set started.
        _started.Set();
        while(!_terminating.WaitOne(0))
        {
            // ...
        }
        _terminated.Set();
    }
    public void FormClosed(object sender, EventArgs e)
    {
        // request for terminating.
        _terminating.Set();
        // wait until it's terminated.
        _terminated.WaitOne();
    }
