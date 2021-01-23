    public partial class MainWindow : Window
    {
        private MyViewModel _viewModel;
    
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MyViewModel();
    
            //Initialize view model with data...
    
            this.DataContext = _viewModel;
        }
    }
