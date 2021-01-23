    string filePath;
    
    public SplashScreen(string FileToDeletePath)
    {
    	InitializeComponent();
    	
    	this.filePath = FileToDeletePath;
    	
    	System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    	timer1.Interval = 3000;
    	timer1.Tick += timer1_Tick;
    	timer1.Start();
    }
    
    void timer1_Tick(object sender, EventArgs e)
    {
    	//delete file
    	if (!string.IsNullOrEmpty(filePath))
    		File.Delete(filePath);
    		
    	//dispose form after deleting the file
    	this.Close();	
    }
