    public frmPhoneQueueViewer()
    {
        InitializeComponent();
        //The default Opacity = 1 won't show your form
        Opacity = 0.2f; //or even Opacity = 0.999 if you like
        //....
        //....
    }
    protected override CreateParams CreateParams {
        get {
             CreateParams cp = base.CreateParams;
             //WS_EX_LAYERED = 0x80000  WS_EX_TRANSPARENT = 0x20
             cp.ExStyle |= 0x80000 | 0x20;                
             return cp;
        }
    }
