        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
                {
                    this.viewModel = this.DataContext as MainViewModel;
                    var dependencies = GetDependencies();
                    this.viewModel.Register(dependencies);
    .
    .
    .
