    System.Timers.Timer _timer = new System.Timers.Timer(1000);  
    bool timerStarted = false;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true;
        _timer.AutoReset = false;
        timerStarted = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        timerStarted = false;
        _timer.Enabled=false;
    }
    void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _timer.Enabled = timerStarted;
    }
