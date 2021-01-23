    System.Timers.Timer _timer = new System.Timers.Timer(10000);
    _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
    protected void Button1_Click(object sender, EventArgs e)
    {        
        _timer.Start();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        _timer.Stop();
    }
