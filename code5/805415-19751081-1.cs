    public MainPage()
        {
            InitializeComponent();
            ViewModel tempViewModel = new ViewModel();
            var strings = new List<string> { "text1", "text2", "text3" };
            tempViewModel.Strings = new ObservableCollection<string>(strings);
            this.DataContext = tempViewModel;
        }
