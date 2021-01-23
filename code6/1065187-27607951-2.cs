    public MainWindow()
    {
      InitializeComponent();
      var connections = System.Configuration.ConfigurationManager.ConnectionStrings;
      DataContext=connections;
    }
