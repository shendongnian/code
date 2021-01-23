    public Building MyBuilding { get; set;}
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        MyBuilding = new Building();
        b.Name = "My Building";
    }
