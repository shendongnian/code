    DispatcherTimer _timer;
    
    public MainWindow()
    {
        _myTimer = new DispatcherTimer();
        _myTimer.Tick += MyTimerTick;
        _myTimer.Interval = new TimeSpan(0,0,0,1);
    }
    
    private void ElementFlowSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _counter = 0;
        _myTimer.Stop();
        _myTimer.Interval = new TimeSpan(0, 0, 0, 1);
        _myTimer.Start();
    }
    
    private int _counter;
    public int Counter
    {
        get { return _counter; }
        set
            {
                _counter = value;
                OnPropertyChanged("Counter");
            }
    }
    private void MyTimerTick(object sender, EventArgs e)
    {
        Counter++;
        if (Counter == 2)
        {
            _myTimer.Stop();
            MessageBox.Show(“Reached the 2 second countdown”);
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler e = PropertyChanged;
        if (e != null)
            {
                e(this, new PropertyChangedEventArgs(propertyName));
    }
    }
