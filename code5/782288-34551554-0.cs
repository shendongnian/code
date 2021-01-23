        DashboardViewModel viewModel;
        public DashboardView()
        {
            InitializeComponent();
            viewModel = new DashboardViewModel();
            viewModel.RequestClose += (s, e) => Application.Current.Dispatcher.Invoke(this.Close);
            viewModel.RequestMinimize += (s, e) => Application.Current.Dispatcher.Invoke(() => { this.WindowState = WindowState.Minimized; });
            DataContext = viewModel;
        }
