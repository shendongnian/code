    public delegate Boolean WaitTestDelegate();
    public static Boolean WaitUntil(WaitTestDelegate testDelegate,
        Int32 milliseconds = 10000, Int32 pariodDuration = 10)
    {
        DateTime startTime = DateTime.Now; Double timeSpan = 0;
        while (!testDelegate() &&
            (timeSpan = (DateTime.Now - startTime).TotalMilliseconds) < milliseconds)
            Thread.Sleep(pariodDuration);
        return timeSpan < milliseconds;
    }
