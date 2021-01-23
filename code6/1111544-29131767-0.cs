    public MainView(IMainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
        SomeViewUc.DataContext = new SomeViewModel(mainViewModel); 
    }
