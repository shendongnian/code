    // Sets the window to be foreground
    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hwnd);
    
    /// <summary>
    /// onVisible focus input username text box
    /// </summary>
    protected override void OnVisibleChanged(EventArgs e)
    {
    	SetForegroundWindow(this.Handle);
    	base.OnVisibleChanged(e);
    }
