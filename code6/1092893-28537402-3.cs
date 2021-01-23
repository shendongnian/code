    [ImportingConstructor]
    public MyView(MyViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
