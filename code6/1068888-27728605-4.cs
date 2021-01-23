    private DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
    public MainPage()
    {
        this.InitializeComponent();
    }
    private void MainPage_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        this.ShowControls();
        // restart the timer whenever the user moves the cursor
        _timer.Start();
    }
    private void Timer_Tick(object sender, object e)
    {
        this.HideControls();
    }
    private void btnPlay_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        _timer.Tick += Timer_Tick;
        this.PointerMoved += MainPage_PointerMoved;
        _timer.Start();
    }
    private void btnPause_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        _timer.Tick -= Timer_Tick;
        this.PointerMoved -= MainPage_PointerMoved;
        _timer.Stop();
    }
    private void HideControls()
    {
        // todo: better use animation here
        this.MyControls.Visibility = Visibility.Collapsed;
        Window.Current.CoreWindow.PointerCursor = null;
    }
    private void ShowControls()
    {
        // todo: better use animation here
        this.MyControls.Visibility = Visibility.Visible;
        Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
    }
