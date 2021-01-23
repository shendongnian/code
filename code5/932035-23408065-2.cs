    private void Window_Loaded(object sender, RoutedEventArgs e)
    {    
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        dispatcherTimer.Start();
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        this.label17.Text=(DateTime.Now.Hour.ToString() + ":" +
        DateTime.Now.Second.ToString());    
    }
