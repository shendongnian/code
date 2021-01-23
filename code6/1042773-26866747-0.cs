    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x014B /* CB_RESETCONTENT */)
        {
            // do something
        }
        base.WndProc(ref m);
    }
