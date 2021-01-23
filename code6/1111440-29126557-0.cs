    public LoginRegister()
        {
            InitializeComponent();
        }
    private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            _lrViewModel = new LrViewModel();
            this.DataContext = _lrViewModel;
        }
