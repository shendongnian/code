    public MainWindow()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Col1", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Col2", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ButtonsList", Type.GetType("WpfApplication.ButtonsList")));
            dt.Rows.Add("Test1", "Test1", new ButtonsList { Content = "Test1", ToolTip = "Test1" });
            dt.Rows.Add("Test2", "Test2", new ButtonsList { Content = "Test2", ToolTip = "Test2" });
            dtGrid.ItemsSource = dt.DefaultView;
        }
