     public Form1()
    {
        InitializeComponent();
    
        axFramerControl1.FrameHookPolicy = OfficeCtrl.ocFrameHookPolicy.ocSetOnFirstOpen;
        axFramerControl1.ActivationPolicy = OfficeCtrl.ocActivationPolicy.ocKeepUIActiveOnAppDeactive;
    }
