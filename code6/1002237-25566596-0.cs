     public MainWindow()
        {
            InitializeComponent();
            List<string> CustName = new List<string>();
            CustName.Add("test1");
            CustName.Add("test2");
            CustName.Add("myselection");
    
    
            listBox1.ItemsSource = CustName;
            string selection = "myselection";  
            listBox1.SelectedItem = selection;
        }
