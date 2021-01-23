    private Timer _timer;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        viewport3D1.Visibility = Visibility.Visible;
        _timer = new Timer(1000); // Set up the timer for 1 seconds
        _timer.Elapsed+=new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true; // Enable it
    }
    public void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Dispatcher.Invoke(new Action(() =>
        {
            viewport3D1.Visibility = Visibility.Hidden;
            viewport3D2.Visibility = Visibility.Visible;
        })); 
    }
