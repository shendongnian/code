    public MainWindow()
    {
        InitializeComponent();
        ViewModel = new ViewModel();
        DataContext = ViewModel;
    }
