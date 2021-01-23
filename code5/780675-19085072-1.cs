    public MainForm()
    {
        InitializeComponent();
        var host = new ServiceHost(typeof(ControlChannel))
        host.Open();
    }
