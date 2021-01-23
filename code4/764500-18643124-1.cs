    public frmPhoneQueueViewer()
    {
        InitializeComponent();
        //The default Opacity = 1 will show your form normally
        Load += (s,e) => {
            appliedStyles = true;
            UpdateStyles();//Call this to apply the styles to make your window able to click through.
        };
        //....
        //....
    }
    bool appliedStyles;
    protected override CreateParams CreateParams {
        get {
             CreateParams cp = base.CreateParams;
             //WS_EX_LAYERED = 0x80000  WS_EX_TRANSPARENT = 0x20
             if(appliedStyles) cp.ExStyle |= 0x80000 | 0x20;                
             return cp;
        }
    }
