    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        DataContext = new ViewModel();
    }
