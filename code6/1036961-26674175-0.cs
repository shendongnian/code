    public MainPage()
    {
        InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (iso.Contains("isoServer") == false)
        {
            iso["isoServer"] = "http://domain.com/appTerminalBD";
            NavigationService.Navigate(new Uri("/tuto.xaml", UriKind.RelativeOrAbsolute));
        }
    }
