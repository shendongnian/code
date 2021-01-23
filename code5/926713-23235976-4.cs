    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m1.Visibility = Visibility.Hidden;
            m2.Visibility = Visibility.Hidden;
            m3.Visibility = Visibility.Hidden;
            m4.Visibility = Visibility.Hidden;
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                m1.Content = DateTime.Now.ToString("HH:mm:ss") + "      Establishing Connection";
                m1.Visibility = Visibility.Visible;
            });
            Thread.Sleep(2000);//your code
            Dispatcher.Invoke(() =>
            {
                m2.Content = DateTime.Now.ToString("HH:mm:ss") + "      Connected";
                m2.Visibility = Visibility.Visible;
            });
            Thread.Sleep(2000);//your code
            Dispatcher.Invoke(() =>
            {
                m3.Content = DateTime.Now.ToString("HH:mm:ss") + "      Processing";
                m3.Visibility = Visibility.Visible;
            });
            Thread.Sleep(2000);//your code
            Dispatcher.Invoke(() =>
            {
                m4.Content = DateTime.Now.ToString("HH:mm:ss") + "      Finished";
                m4.Visibility = Visibility.Visible;
            });
            Thread.Sleep(2000);//your code
        }
    }
