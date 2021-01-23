    public MainWindow()
    {
        ViewModel = new MyViewModel();
        InitializeComponent();
    }
    public MyViewModel ViewModel { get; set; }
