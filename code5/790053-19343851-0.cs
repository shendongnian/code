    public MainWindow()
    {
        InitializeComponent();
        var ctx = new AdventureWorksContext();
        Employees = TreeBuilder.BuildEmployeeTree(ctx.Employees);
        DataContext = this;
    }
