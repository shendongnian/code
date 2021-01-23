    private readonly Stopwatch _watch;
    private double _yourValue;
    public Ctor()
    {
        _watch = Stopwatch.StartNew();
    }
    public double YourValue
    {
        get { return _yourValue; }
        set
        {
            if (Math.Abs(value - _yourValue) < Double.Epsilon) return;
            // Always save value
            _yourValue = value;
            // Only trigger notification after a certain amount of time 
            // (e.g. once every second)
            if (_watch.ElapsedMilliseconds > 1000)
            {
                OnPropertyChanged();
                _watch.Restart();
            }
        }
    }
