    const int WM_LBUTTONDOWN = 0x0201;
    const int WM_LBUTTONDBLCLK = 0x0203;
    protected override void WndProc(ref Message m)
        {
            // only open dropdownlist when the user clicks on the arrow on the right, not anywhere else...
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK)
            {
                int x = m.LParam.ToInt32() & 0xFFFF;
                if (x >= Width - SystemInformation.VerticalScrollBarWidth)
                    base.WndProc(ref m);
                else
                {
                    Focus();
                    Invalidate();
                }
            }
            else
                base.WndProc(ref m);
        }
