    using (var log = GetLog())
    {
        log.WriteLine("["+DateTime.Now + "]: ");
    }
...
    public StreamWriter GetLog()
    {
        return new StreamWriter(LogFile, File.Exists(LogFile));
    }
