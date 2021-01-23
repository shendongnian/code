    // Field for the viewmodel
    private LinkViewModel vm;
    
    public LinkWindow(string path)
    {
        InitializeComponent();
        vm = new LinkViewModel(path);
        this.DataContext = vm;     
    }
