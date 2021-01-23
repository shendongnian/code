        public MainWindow()
        {
            URIs = new ObservableCollection<URIPairing>();
            InitializeComponent();
            this.URIs.Add(new URIPairing("DEV", "Some URL"));
            this.URIs.Add(new URIPairing("SANDBOX", "Some URL"));
            this.URIs.Add(new URIPairing("QA", "Some URI"));
        }
