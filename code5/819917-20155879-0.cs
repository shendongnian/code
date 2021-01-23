    private ManualResetEvent suspendEvent = new ManualResetEvent(false);
    private bool shutdown;
    private void RunThread()
    {
        while (!shutdown)
        {
            suspendEvent.WaitOne();
            if (shutdown)
            {
                break;
            }
            Notify("Cleaning started!");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Notify("Cleaning finished!");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
