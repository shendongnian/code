    public void NonblockingListener()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://*:8081/");
        listener.Start();
        IAsyncResult result = listener.BeginGetContext(
            new AsyncCallback(HttpListenerCallback), listener);
        Console.WriteLine("Waiting for request to be processed asyncronously.");
        result.AsyncWaitHandle.WaitOne(); //just needed to don't close this thread, you can do other work or run in a loop
        Console.WriteLine("Request processed asyncronously.");
        listener.Close();
    }
