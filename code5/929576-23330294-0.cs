    public partial class MainWindow : Window
    {
        BackgroundWorker loadInfo = new BackgroundWorker();
        private List<string> stringArrayItems = new List<string>{
            "First file",
            "second file",
            "third file ",
            "fourth file "
        };
        public MainWindow()
        {
            InitializeComponent();
            loadInfo.DoWork += loadInfo_DoWork;
            loadInfo.RunWorkerCompleted += loadInfo_RunWorkerCompleted;
            loadInfo.WorkerReportsProgress = true;
            loadInfo.RunWorkerAsync();
        }
        public void loadInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateContentLabel("Load complete :)");
        }
        public void loadInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() => UpdateContentLabel("Loading items")));
            foreach (string i in stringArrayItems)
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                    UpdateContentLabel("Loading " + i + " info...")
                ));
                
                //LoadTasks
                Thread.Sleep(1000);
                Console.Out.WriteLine("Loading {0} and sleeping for a second.", i);
            }
        }
        void UpdateContentLabel(string Task)
        {
            MyLabel.Content = Task;
        }
    }
