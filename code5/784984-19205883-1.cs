    public MainWindow()
    {
        InitializeComponent();
        DBCoding dbobj = new DBCoding();
        List<string> online = dbobj.onlineUsers();
        DataContext = online;
    }
