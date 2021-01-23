    public void Start(int bbm)
    {
        _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        _timer.Start();
    }
    public void Stop()
    {
        _timer.Stop();
    }
