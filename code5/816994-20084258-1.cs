    private readonly MainViewModel _viewModel;
    public MainWindow()
            {
                InitializeComponent();
                _viewModel = new MainViewModel();
                this.DataContext = _viewModel;
            }
