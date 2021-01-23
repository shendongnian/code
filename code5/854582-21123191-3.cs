    public MainPageViewModel ViewModel
    {
        get
        {
            return this.DataContext as MainPageViewModel;
        }
    }
    public MainPageView()
    {
        InitializeComponent( );
        DataContext = new MainPageViewModel( null, this );
    }
