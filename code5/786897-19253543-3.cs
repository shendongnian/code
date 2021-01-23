    public MainWindow()
    {
        InitializeComponent();
        Log = new Model.MessageLog(); // <- This line before setting the DataContext
        DataContext = this;
    }
