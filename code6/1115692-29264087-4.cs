    public MainWindow()
        {
            InitializeComponent();
            ComboColor.ItemsSource = typeof(Colors).GetProperties();
        }
