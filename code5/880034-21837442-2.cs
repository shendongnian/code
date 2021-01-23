     public MainWindow()
        {
            InitializeComponent();
            MovingItemViewModel vm = new MovingItemViewModel();
            DataContext = vm;
        }
