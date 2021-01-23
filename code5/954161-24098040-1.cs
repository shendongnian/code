        public MainWindow()
        {
            InitializeComponent();
            viewModel= new ViewModel();
            this.DataContext = viewModel;
        }
 
        public ViewModel viewModel{ get; set; }
