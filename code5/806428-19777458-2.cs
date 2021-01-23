    private readonly SongPlayerViewModel _viewModel = new SongPlayerViewModel();
    
    public MainWindow() 
    {
       InitializeComponent();
       DataContext = _viewModel;
    }
