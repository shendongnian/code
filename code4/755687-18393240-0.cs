    public static string k=string.Empty;    
    public ManualResetEvent waitForStringEvent = new ManualResetEvent(false);
    public void SomeMethod()
    {
        k=someObject.Method(byte[]);// this returns some string this methods takes some time to execute
        // After a while, someObject.Method() will return, and we'll signal the event
        waitForStringEvent.Set();
        // ...
    }
    Public string CollectMethod(string K);
    {
        waitForStringEvent.WaitOne(); // This will block until signaled
        return k;// Return whatever is in k once signalled
    }
