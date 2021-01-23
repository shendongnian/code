    public Form1()
    {
        InitializeComponent();
        _timer.Interval = 1000;
        _timer.Tick += delegate
        {
            RealTimeTimer();
        };
    }
.
     private void RealTimeTimer()
    {
        Delete();
    }
