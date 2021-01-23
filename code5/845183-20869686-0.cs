    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(TimerElapsedHandler, null, 0, 1000);
        }
        private void TimerElapsedHandler(object state)
        {
            this.Dispatcher.Invoke(() => { timeLabel.Content = DateTime.Now.ToLongTimeString(); });
        }
    }
