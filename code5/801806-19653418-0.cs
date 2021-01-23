    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    dispatcherTimer.Tick += dispatcherTimer_Tick;
    dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 500);
    private void dispatcherTimer_Tick(object sender, EventArgs e) {
       // assign new source to the Image
    }
