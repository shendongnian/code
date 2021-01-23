    public MyViewModel ModelView;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = ModelView = new MyViewModel ();
    }
