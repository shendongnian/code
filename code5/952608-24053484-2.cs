    public MainPage()
    {
        InitializeComponent();
        LoginViewModel vm = new LoginViewModel();
        this.DataContext = vm;
    }
