    public static MainWindow Instance { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        if(Instance == null)
            Instance = new MainWindow();
    }
    public static MainWindow Instance { get; private set; }
