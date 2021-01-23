            public MainWindow()
        {
          
            InitializeComponent();
            cmbContent=new ObservableCollection<string>();
            cmbContent.Add("test 1");
            cmbContent.Add("test 2");
            cmbTest.ItemsSource = cmbContent;
         
        }
        public ObservableCollection<string> cmbContent { get; set; }
