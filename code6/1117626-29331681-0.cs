    public event EventHandler DataReceived;
    private bool _done;
    private void PortListener(EventWaitHandle waitHandle)
    {
        while (true)
        {
            waitHandle.WaitOne();
            if (_done)
            {
                break;
            }
            EventHandler handler = DataReceived;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    public void StartListening(EventWaitHandle waitHandle)
    {
        _done = false;
        new Thread(() => PortListener(waitHandle)).Start()
    }
    public void StopListening(EventWaitHandle waitHandle)
    {
        _done = true;
        waitHandle.Set();
    }
