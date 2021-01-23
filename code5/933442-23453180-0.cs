     public partial class MainWindow : Window
    {
        private ObservableCollection<int> myVar;
        public ObservableCollection<int> MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        BackgroundWorker bw;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MyProperty = new ObservableCollection<int>();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
           for(int i = 0; i < 10;i++)
           {
               MyProperty.Add(i);
           }
        }
    }
