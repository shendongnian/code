     public partial class MainWindow : Window
    {
        BackgroundWorker _worker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += worker_DoWork;
            _worker.ProgressChanged += worker_ProgressChanged;
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress1.Value = e.ProgressPercentage;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var files = new List<string>();
            foreach(var file in files)
            {
                File.Move(file, /*target*/);
                _worker.ReportProgress(/* here is progress from 0 to 100 */)
            }
        }
    }
