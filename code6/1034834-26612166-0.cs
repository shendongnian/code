    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0100) //WM_KEYDOWN
        {
            if ((int)m.WParam == 0x2C) //VK_SNAPSHOT
            {
                //...
            }
        }
        base.WndProc(ref m);
    }
