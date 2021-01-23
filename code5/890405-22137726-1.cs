    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel
            {
                ListItems = new ObservableCollection<MyModel>
                {
                    new MyModel
                    {
                        MyPropertyText = "hello",
                        ShowText = true,
                        ShowTextbox = Visibility.Visible
                    }
                }
            };
            DataContext = _mainViewModel;
        }
        public void test()
        {
        }
    }
