    protected override void WndProc(ref Message m)
    {
        // http://msdn.microsoft.com/en-us/library/windows/desktop/hh454920(v=vs.85).aspx
        // 0x210 is WM_PARENTNOTIFY
        // 513 is WM_LBUTTONCLICK
        if (m.Msg == 0x210 && m.WParam.ToInt32() == 513) 
        {
            var x = (int)(m.LParam.ToInt32() & 0xFFFF);
            var y = (int)(m.LParam.ToInt32() >> 16);
    
            var childControl = this.GetChildAtPoint(new Point(x, y));
            if (childControl == cancelButton)
            {
                // ...
            }
        }
        base.WndProc(ref m);
    }
