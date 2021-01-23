    public partial class MainWindow : Window
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_CallDatabase(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(CallDatabase, _cancellationTokenSource.Token);
        }
        private void Button_OnNavigate(object sender, RoutedEventArgs e)
        {
            // If you navigate, you can cancel the background task and thus
            // it will not execute any further
            _cancellationTokenSource.Cancel();
        }
        private void CallDatabase()
        {
            // This simulates a DB call
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
            }
            // Check if cancellation was requested
            if (_cancellationTokenSource.Token.IsCancellationRequested)
            {
                Debug.WriteLine("Request cancelled");
                return;
            }
            Debug.WriteLine("Update Controls with DB infos.");
        }
    }
