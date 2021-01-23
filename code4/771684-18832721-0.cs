    static void Main(string[] args)
    {
        ManualResetEvent signal = new ManualResetEvent(false);
        //start asynchronous work
        //call signal.Set(); to close the application
        signal.WaitOne();
    }
