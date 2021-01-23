        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private string _dataString = "No Data";
        public string DataString
        {
            get { return _dataString; }
            set {
                if (_dataString != value)
                {
                    _dataString = value;
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DataString"));
                }
            }
        }
