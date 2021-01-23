    private const int WM_ERASEBKGND = 20;
    [PermissionSet(SecurityAction.Demand, Unrestricted=true)]
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_ERASEBKGND)
        {
            m.Result = IntPtr.Zero;
        }
        else
        {
            base.WndProc(ref m);
        }
    }
