    private ILog _log;
    
    public ILog Log
    {
        get { return _log ?? (_log = LogManager.GetLogger(LogName.WebServices)); }
    }
