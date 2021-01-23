    public event Action<object> Maximized;
    public event Action<object> Minimized;
    protected override void WndProc(ref Message m) {
        if (m.Msg == 0x0112) { // WM_SYSCOMMAND
            // Check your window state here
            if (m.WParam == new IntPtr(0xF030) && Maximized != null) Maximized(this);// Maximize event - SC_MAXIMIZE from Winuser.h
            if (m.WParam == new IntPtr(0XF020) && Minimized != null) Minimized(this);// Minimize event - SC_MINIMIZE from Winuser.h
        }
        base.WndProc(ref m);
    }
