    public Form1()
    {
        InitializeComponent();
    
        
        _capture = new Capture();   
        Application.Idle += ProcessFrame;
    }
    
    private void ProcessFrame(object sender, EventArgs arg)
    {
        Image<Bgr, Byte> currentFrame = _capture.QueryFrame();
        currentFrame =currentFrame.Rotate(90,new Bgr(255,255,255),true);
        // other code to the task you want to achieve like displaying in ImageBox etc.
        
    
    }
    
