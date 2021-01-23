    public MainPage()
    {
        InitializeComponent();
        //Here you set the ViewModel
        this.DataContext = App.ViewModel;
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //Here you load the data   
        App.ViewModel.LoadData();
    }
