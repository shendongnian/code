    public MainForm()
    {
        InitializeComponent();
        using (var host = new ServiceHost(typeof(ControlChannel)))
        {
            host.Open();
        }
    }
