    NavigationService service;
    public MainWindow()
    {
        InitializeComponent();
        service = mainframe.NavigationService;
        service.Navigate("Page2.xaml");
    }
    
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (service.CanGoBack)
            service.GoBack();
    }
