    public partial class MainWindow : Window
    {
        private BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                Label lbl = new Label();
                lbl.Content = e.ProgressPercentage;
                stackPanel1.Children.Add(lbl);
            }), DispatcherPriority.Background);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.IsEnabled = true;
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                worker.ReportProgress(DataSupplier.GenerateRandomInt());
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            worker.RunWorkerAsync();
        }
        private int GenerateRandomInt(int i)
        {
            Thread.Sleep(1000);
            return i;
        }
    }
    class DataSupplier
    {
        public static int GenerateRandomInt()
        {
            Random rnd = new Random();
            Thread.Sleep(1000);
            return rnd.Next();
        }
    }
