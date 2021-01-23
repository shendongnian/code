    public void WaitForReaderArrival()
    {
        while (!ReaderArrived())
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
        }
    }
