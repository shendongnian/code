    public MainPage()
    {    
    InitializeComponent();
    
    webBrowser1.Loaded += WebBrowser_OnLoaded;
    }
    private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
    {
    
    webBrowser1.Navigate(new Uri("readme.htm", UriKind.Relative));
    }
