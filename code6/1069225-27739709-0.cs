    private TimeSpan time;
    
    private void Timer()
    {    
        DispatcherTimer stopwatch_timer = new DispatcherTimer();    
        stopwatch_timer.Interval = new TimeSpan(0, 0, 0, 1, 0);    
        stopwatch_timer.Tick += new EventHandler(stopwatch_timer_Tick);    
        stopwatch_timer.Start();    
        time = stopwatch_timer.Interval;    
    }
            
    void stopwatch_timer_Tick(object sender, EventArgs e)
    {    
       TimerDisplay.Text = time.ToString();    
       time = time.Add(((DispatcherTimer)sender).Interval);       
    }
