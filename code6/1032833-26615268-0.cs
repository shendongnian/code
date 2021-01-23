    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x020A) //WM_MOUSEWHEEL
        {
            if(tabControl1 .SelectedIndex == 0) //0 index where flowLayoutPanel1 is
            {
                 //send the message to flowLayoutPanel1
                 SendMessage(flowLayoutPanel1.Handle, (UInt32)m.Msg, m.WParam, m.LParam);
            }
        }
        base.WndProc(ref m);
    }
