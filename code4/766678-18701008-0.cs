    [DllImport("User32")]
    public static extern bool RegisterHotKey(
        IntPtr hWnd,
        int id,
        int fsModifiers,
        int vk
    );
    [DllImport("User32")]
    public static extern bool UnregisterHotKey(
        IntPtr hWnd,
        int id
    );
    public const int MOD_SHIFT = 0x4;
    public const int MOD_CONTROL = 0x2;
    public const int MOD_ALT = 0x1;
    public const int WM_HOTKEY = 0x312;
    
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_HOTKEY && m.WParam == (IntPtr)0)
        {
            IntPtr lParamCTRLA = (IntPtr)4259842;
            IntPtr lParamB = (IntPtr)4325376;
            if (m.LParam == lParamCTRLA)
            {
                MessageBox.Show("CTRL+A was pressed");
            }
            else if (m.LParam == lParamB)
            {
                MessageBox.Show("B was pressed");
            }
        }
        base.WndProc(ref m);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
    
        RegisterHotKey(this.Handle, 0, MOD_CONTROL, (int)Keys.A);
        RegisterHotKey(this.Handle, 0, 0, (int)Keys.B);
    }
    
    private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
    {
        UnregisterHotKey(this.Handle, 0);
    }
