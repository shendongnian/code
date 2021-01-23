    private Timer _timer;
    private ILog _logger = LogManager.GetLogger("root"); // Get the log4net logger
    private const int _timeoutInMilliseconds = 10000;    // 10 seconds
    public void Start()
    {
        _timer = new Timer(new TimerCallback(timerTick),
                null,
                _timeoutInMilliseconds, // Timeout to wait until the callback is called
                Timeout.Infinite        // Makes sure it's only called once
             );
    }
    private void timerTick(object sender)
    {
        _logger.Info("Sample");
        _timer.Change(_timeoutInMilliseconds, Timeout.Infinite); // Wait 10 seconds again
    }
