    DispatcherTimer timer = new DispatcherTimer();
    // Call this method after the 60 seconds countdown.
    public void Start_timer()
    {        
        timer.Tick += timer_Tick;
        timer.Interval = new TimeSpan(0, 0, 5);
        bool enabled = timer.IsEnabled;
        // Check and show answer is correct or wrong
        timer.Start();       
    }
    
    void timer_Tick(object sender, object e)
    {
        this.Visibility = System.Windows.Visibility.Visible;
        (sender as DispatcherTimer).Stop(); // Or you can just call timer.Stop() if the timer is a global variable.
        // Clear screen, go to the next question
    }
