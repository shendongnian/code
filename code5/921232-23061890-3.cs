    public MainPage()
            {
                InitializeComponent();
                ViewModel.PhotoItemViewModel _vm = new ViewModel.PhotoItemViewModel();
                this.DataContext = _vm;
            }
