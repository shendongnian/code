    public MainWindow()
    {
        InitializeComponent();
    
    	FileSystemWatcher fsw = new FileSystemWatcher();
    	fsw.Filter = "test1.csv";
    	fsw.NotifyFilter = NotifyFilters.LastWrite;
    	fsw.Path = "z:\\temp\\";
    	fsw.Changed += Fsw_Changed;
    	fsw.EnableRaisingEvents = true;    
    }
    
    private void Fsw_Changed(object sender, FileSystemEventArgs e)
    {
    	MessageBox.Show(e.FullPath);
    }
