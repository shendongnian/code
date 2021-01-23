    public MainWindow()
    {
        InitializeComponent();
        MyModel = new MyModel { MyCounter = new Counter() };
        this.DataContext = MyModel;
    }
