    public partial class MainWindow : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged section
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        private List<int> availableListItems;
        public List<int> AvailableListItems
        {
            get
            {
                return availableListItems;
            }
            set
            {
                availableListItems = value;
                OnPropertyChanged("AvailableListItems");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            AvailableListItems = new List<int>();
            this.DataContext = this;
        }
        BackgroundWorker loadInfo = new BackgroundWorker();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadInfo.DoWork += loadInfo_DoWork;
            loadInfo.WorkerReportsProgress = true;
            loadInfo.RunWorkerAsync();
        }
        public void loadInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 2000; i++)
            {
                AvailableListItems.Add(i);
                Thread.Sleep(1);
                OnPropertyChanged("OnPropertyChanged");
            }
        }
    }
