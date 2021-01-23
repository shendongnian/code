    //Listen for the hotkey
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_HOTKEY)
        {
            Keys vk = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            int fsModifiers = ((int)m.LParam & 0xFFFF);
            //Perform action when hotkey is pressed
            if (vk == userHotkey)
            {
                minimizeWindow();
            }
        }
    }
    //Minimize the currently active window
    private void minimizeWindow()
    {
        //Get a pointer to the currently active window
        IntPtr hWnd = getCurrentlyActiveWindow();
        if (!hWnd.Equals(IntPtr.Zero))
        {
            //Minimize the window
            ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
        }
    }
    //Get the currently active window
    private IntPtr getCurrentlyActiveWindow()
    {
        this.Visible = false;
        return GetForegroundWindow();
    }
