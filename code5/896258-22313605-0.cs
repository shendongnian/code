    public MainPage()
    {
        InitializeComponent();
        time.Tick += time_Tick;
    }
    //Starting Countdown
    private void Start_Click_1(object sender, RoutedEventArgs e)
    {
        left = 60; // time left
        time.Interval = TimeSpan.FromSeconds(1);
        time.Start();
    }
