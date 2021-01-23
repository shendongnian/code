    private System.Timers.Timer _timer;
    private void CreateTimer()
    {
        _timer = new System.Timers.Timer();
        _timer.Enabled = false;
        _timer.Interval = 100;  // default
        _timer.Elapsed += new ElapsedEventHandler(timerEvent);
        _timer.AutoReset = true;
        _timer.Enabled = true;    
    }
    private void TimerButton_Click(object sender, EventArgs e)
    {
        bool isNumeric = int.TryParse(ImgTimeInterval.Text, out timerMS); //if number place number in timerMS
        label2.Text = isNumeric.ToString();
        if (isNumeric)
        {
            _timer.Interval = timerMS;
        }
    }
    public void timerEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        label1.Text = counter.ToString();
        counter = (counter + 1) % 100;
    }
