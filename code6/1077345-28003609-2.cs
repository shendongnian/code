    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        switch (m.Msg)
        {
            case WM_KEYDOWN:
            {
                int lParam = m.LParam.ToInt32();
                int scanCode = (lParam >> 16) & 0x000000ff; // extract bit 16-23
                int ext = (lParam >> 24) & 0x00000001; // extract bit 24
                if (ext == 1) 
                    scanCode += 128;
                
                this.HandleScanCode(scanCode);
                break;
            }
        }
    }
