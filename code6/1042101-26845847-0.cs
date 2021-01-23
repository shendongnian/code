    private double counter = 0.0;
    private double frequency = 100.0;
    private DispatcherTimer dispatch = new DispatcherTimer();
    
    public Timer()
    {
        // You may want integer division in this line to get full milliseconds
        this.dispatch.Interval = TimeSpan.FromMilliseconds((int)(1000.0 / frequency));
        this.dispatch.Tick += new EventHandler(updateTimer);
        this.dispatch.Start();
    }
    
    private void updateTimer(object sender, EventArgs e)
    {
        counter = counter >= frequency ? 0.0 : counter + 1.0;
        saveImage.RenderTransform = new RotateTransform(counter * 3.6);
    }
