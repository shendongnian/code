    public string Get()
    {
        string ts = DateTime.Now.ToString("mm:ss.fff");
        Thread.Sleep(2000);
        return ts;
    }
