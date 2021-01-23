    public LinkWindow(string path, object viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;    
    }
