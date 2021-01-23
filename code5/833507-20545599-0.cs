    public partial class MainWindow : Window
    {
        BackgroundWorker Worker;
        public MainWindow()
        {
            InitializeComponent();
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            Worker.RunWorkerAsync("param");
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            tb.Dispatcher.Invoke((Action)(() =>
            {
                tb.Text = "doing work: " + (e.Argument as string);
            }));
            Thread.Sleep(5000);
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tb.Dispatcher.Invoke((Action)(() =>
            {
                tb.Text = "finished work";
            }));
        }
    }
