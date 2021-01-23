    [System.Runtime.InteropServices.DllImport("User32")] public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
    [System.Runtime.InteropServices.DllImport("User32")] public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
    public const int MOD_SHIFT = 0x4;
    public const int MOD_CONTROL = 0x2;
    public const int MOD_ALT = 0x1;
    public const int WM_HOTKEY = 0x312;
    public const int MOD_WIN = 0x0008;
    
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_HOTKEY && m.WParam == (IntPtr)0)
        {
            IntPtr lParamWINZ = (IntPtr)5898248;
            IntPtr lParamWINCTRLA = (IntPtr)4259850;
            if (m.LParam == lParamWINZ)
            {
                MessageBox.Show("WIN+Z was pressed");
            }
            else if (m.LParam == lParamWINCTRLA)
            {
                MessageBox.Show("WIN+CTRL+A was pressed");
            }
        }
        base.WndProc(ref m);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
    
        RegisterHotKey(this.Handle, 0, MOD_WIN, (int)Keys.Z);
        RegisterHotKey(this.Handle, 0, MOD_WIN + MOD_CONTROL, (int)Keys.A);
    }
    
    private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
    {
        UnregisterHotKey(this.Handle, 0);
    }
