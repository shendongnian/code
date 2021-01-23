    private frm_lockscreen _lockScreen;
    private frm_lockscreen LockScreen
    {
        get { return _lockScreen ?? (_lockScreen = new frm_lockscreen()); }
    }
    private void tmr_sysdt_Tick(object sender, EventArgs e)
    {
        // prevent reentry
        if (!Monitor.TryEnter(tmr_sysdt)) return;
        try {
            lbl_time.Text = System.DateTime.Now.ToLongTimeString();
            lbl_date.Text = System.DateTime.Now.ToLongDateString();
            if (GetLastInputTime() > Program.timeout)
            {
                tmr_sysdt.Enabled = false;
                if (LockScreen.ShowDialog(this) == DialogResult.OK) tmr_sysdt.Enabled = true;
            }
        }
        finally {
            Monitor.Exit(tmr_sysdt);
        }
    }
