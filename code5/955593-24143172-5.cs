    public partial class MainWindow
    {
        private readonly Action _onLoaded;
        public MainWindow(Action onLoaded)
        {
            _onLoaded = onLoaded;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _onLoaded();
        }
    }
