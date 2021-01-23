    private GlobalHotKey globalHotKey;
    // Registering your hotkeys
    private void Form2_Load(object sender, EventArgs e)
    {
        globalHotKey = new HotKeys.GlobalHotKey(Constants.CTRL, Keys.F12, this);
        bool registered = globalHotKey.Register();
        // Handle instances where the hotkey failed to register
        if(!registered)
        {
            MessageBox.Show("Hotkey failed to register");
        }
    }
    // Listen for messages matching your hotkeys
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == HotKeys.Constants.WM_HOTKEY_MSG_ID)
        {
            HandleHotkey();
        }
        base.WndProc(ref m);
    }
    // Do something when the hotkey is pressed
    private void HandleHotkey()
    {
        if(this.Visible)
            this.Hide();
        else
            this.Show();
    }
