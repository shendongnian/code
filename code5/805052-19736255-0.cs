    private void UpdateThread()
    {
        while (running) //I'm assuming running is a volatile variable
        {
           ReadPos();
           Thread.Sleep(100);
        }
    }
