    private static object globalLock = new object();
    public bool Method1()
    {
        lock (globalLock)
        {
            Thread.Sleep(15000);
            return true;
        }
    }
