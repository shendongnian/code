    System.Timers.Timer _timer; 
    _timer = new System.Timers.Timer(10000);
    protected void Button1_Click(object sender, EventArgs e) 
    {           
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true;
    }
    protected void Button2_Click(object sender, EventArgs e) 
    {
      _timer.Stop(); 
    }
