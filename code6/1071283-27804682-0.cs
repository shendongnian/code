    bool windowStateSetByShortcut = false;
    
    protected override void WndProc(ref Message m)
    {
        /*WM_SIZE*/
        if (m.Msg == 0x0005)
        {
            windowStateSetByShortcut = true;     
        }
        base.WndProc(ref m);
    }
    
    protected override void OnLoad(EventArgs e)
    {    
        if (!windowStateSetByShortcut)
        {
            WindowState = FormWindowState.Normal;
        }
        base.OnLoad(e);
    }
