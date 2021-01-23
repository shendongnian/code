    [DllImport("user32.dll")]
    public static extern int SetCursor(IntPtr cursor);
    private const int WM_SETCURSOR = 0x20;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg == WM_SETCURSOR)
        {
            var scrollbarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            var x = PointToClient(Control.MousePosition).X;
            var inScrollbar = x > this.Width - scrollbarWidth;
            var cursor = inScrollbar ? Cursors.Arrow : Cursors.IBeam;
            SetCursor(cursor.Handle);
            m.Result = new IntPtr(1); //Signify that we dealt with the message. We should be returning "true", but I can't figure out how to do that.
            return;
        }
        base.WndProc(ref m);
    }
