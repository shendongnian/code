    private void TimerUpdater()
    {
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        timer.Start();
    }
    
    public int counter;
    
    void timer_Tick(object sender, EventArgs e)
    {
        counter++;
        TbTimer.Text = counter.ToString();
    }
