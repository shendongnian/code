    bool windowStateSetByShortcut = false;
    
    protected override void WndProc(ref Message m)
    {
        /*WM_SIZE*/
        if (m.Msg == 0x0005)
        {
            // This will be set to true if the shortcut uses the Maximized or Minimized
            // options because then it runs before OnLoad.
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
