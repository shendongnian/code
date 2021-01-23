    //  DispatcherTimer setup
    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = new TimeSpan(0,0,1);
    dispatcherTimer.Start();
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        //check your users text
    }
