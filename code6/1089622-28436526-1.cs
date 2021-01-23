    public MainView()
    {
        InitializeComponent();
            
        var viewModel = SimpleIoc.Default.GetInstance<MainViewModel>();
        DataContext = viewModel;
        Loaded += (s, e) => viewModel.LoadData();
    }
