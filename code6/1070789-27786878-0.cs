    private ObservableCollection<CLogMessage> _logs = 
        new ObservableCollection<CLogMessage>();
    public ObservableCollection<CLogMessage> logs
    {
        get { return _logs; }
    }
    public void AddString(string source, string message)
    {
        CLogMessage log = new CLogMessage();
        log.time = DateTime.Now;
        log.source = source;
        log.message = message;
        System.Windows.Application.Current.Dispatcher.Invoke(
            (Action)delegate()
        {
            _logs.Add(log);
        });
    }
