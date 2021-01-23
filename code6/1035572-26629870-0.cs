    private DispatcherTimer timer;
    private int imageIndex = 2;
    public MainWindow()
    {
        InitializeComponent();
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += TimerTick;
        timer.Start();
    }
    private void TimerTick(object sender, EventArgs e)
    {
        image.Source = new BitmapImage(
            new Uri(@"C:\Users\Pictures\Braccio" + imageIndex + ".jpg"));
        if (++imageIndex == 5)
        {
            imageIndex = 2;
        }
    }
