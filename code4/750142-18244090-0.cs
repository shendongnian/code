    public void Error(Func<string> messageGenerator)
    {
        //_log is an NLog logger
        _log.Error(new LogMessageGenerator(messageGenerator));
    }
