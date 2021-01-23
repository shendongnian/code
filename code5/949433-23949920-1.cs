    Stopwatch sw;
    DispatcherTimer timer;
    public MainPage()
    {
        this.InitializeComponent();
        this.NavigationCacheMode = NavigationCacheMode.Required;
        sw = new Stopwatch();
        timer = new DispatcherTimer();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        sw.Start();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (i, j) => { txtBlock.Text = sw.Elapsed.ToString(); };
        timer.Start();    
    }
