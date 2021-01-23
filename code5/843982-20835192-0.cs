    public MainPage()
    {
        this.InitialieComponent();
        
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMinutes(5);
        timer.Tick += (sender, e) =>
        {
            //...
        };
        timer.Start();
    }
