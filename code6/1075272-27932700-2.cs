    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetScrollPos(IntPtr hWnd, int nBar);
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0115) // WM_VSCROLL
        {
            int scrollPos = MyDataGridView.GetScrollPos(this.Handle, 1); // SB_VERT
            // get the vertical scroll position
            this.button1.Y = desiredY + scrollPos;
            // you'll need to calculate where all the buttons should be, then offset them by the scroll pos
        }
        base.WndProc(ref m);
    }
