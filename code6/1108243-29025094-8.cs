    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x84)
        { 
            const int resizeArea = 10;
            Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
            if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea )
            {
                m.Result = (IntPtr)17;
                return;
            }
        }
        base.WndProc(ref m);
    }
