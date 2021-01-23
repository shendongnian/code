    string filePath;
    
    public SplashScreen(string FileToDeletePath)
    {
    	InitializeComponent();
    	
    	this.filePath = FileToDeletePath;
    	
    	System.Timers.Timer timer1 = new System.Timers.Timer();
    	timer1.Interval = 30000;
    	timer1.Elapsed += timer1_Elapsed;
    }
    
    void timer1_Elapsed(object sender, ElapsedEventArgs e)
    {
    	//delete the file using "filePath"
    }
