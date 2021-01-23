    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromMilliseconds(10000); // checks every 10 seconds
    timer.Tick += Timer_Tick;
    timer.Start();
    ...
    private void Timer_Tick(object sender, EventArgs e)
    {
        // do your checks here
        textbox.Text = ProcessStatus;
    }
