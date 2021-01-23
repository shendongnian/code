    protected override void WndProc(ref Message m)
    {
        // Trap WM_PASTE with image:
        if (m.Msg == 0x302 && Clipboard.ContainsImage())
        {
            return;
        }
        base.WndProc(ref m);
    }
