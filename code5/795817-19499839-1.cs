    private Control lastInputControl { get; set; }
    protected override void WndProc(ref Message m)
    {
        // WM_SETFOCUS fired.
        if (m.Msg == 0x0007)
        {
            if (ActiveControl is TextBox)
            {
                lastInputControl = ActiveControl;
            }
        }
        
        // Process the message so that ActiveControl might change.
        base.WndProc(ref m);
        if (ActiveControl is TextBox && lastInputControl != ActiveControl)
        {
            lastInputControl = ActiveControl;
        }
    }
    public void CopyActiveText()
    {
            if (lastInputControl == null) return;
            Clipboard.SetText(lastInputControl.Text);
    }
