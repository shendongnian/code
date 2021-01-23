    public MainPage()
    {
        this.InitializeComponent();
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(n);
        timer.Tick += (sender, e) =>
        {
            //  ...
            //  image.Source = ...
        };
        timer.Start();           
    }
    
