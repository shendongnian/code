    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Timer _clockTimer;
    
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
    
           _clockTimer = new Timer(1000); // The interval is in milliseconds
           _clockTimer.Elapsed += (sender, e) =>
           {
               LabelValue = System.DateTime.Now.ToString();
           };
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
                OnPropertyChanged("LabelValue");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
