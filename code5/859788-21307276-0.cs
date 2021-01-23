        public SmStatusBar StatusBar 
        {
            get { return this.sbMain; }
        }
        public MainWindow()
        {
            InitializeComponent();
            CommonHelper.SmMainWindow = this;
        }
