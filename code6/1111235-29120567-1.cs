    public static MainWindow Instance { get; private set; }
        static MainWindow()
    {
        Instance = new MainWindow();
    }
    
    private MainWindow()
    {
        InitializeComponent();
    }
