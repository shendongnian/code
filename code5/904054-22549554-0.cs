    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Task.Run(() => UpdateLabel());
        }
        private string _lblValue;
        public string LabelValue
        {
            get
            {
                return _lblValue;
            }
            set
            {
                _lblValue = value;
                OnPropertyChanged();
            }
        }
        private void UpdateLabel()
        {
            while (true)
            {
                LabelValue = System.DateTime.Now.ToString();
                System.Threading.Thread.Sleep(1000);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
