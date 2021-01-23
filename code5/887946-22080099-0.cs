    #region Enable / Disable Close Button
    [DllImport("user32.dll", CharSet=CharSet.Auto)]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    
    [DllImport("user32.dll", CharSet=CharSet.Auto)]
    private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
    
    private const int SC_CLOSE		= 0xF060;
    private const int MF_BYCOMMAND	= 0x0000;
    
    private const int MF_ENABLED	= 0x0000;
    private const int MF_GRAYED		= 0x0001;
    
    protected void DisableCloseButton()
    {
    	try
    	{
    		EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
    		this.CloseButtonIsDisabled = true;
    	}
    	catch{}
    }
    protected void EnableCloseButton()
    {
    	try
    	{
    		EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_BYCOMMAND | MF_ENABLED);
    		this.CloseButtonIsDisabled = false;
    	}
    	catch{}
    }
    protected override void OnSizeChanged(EventArgs e)
    {
    	if (this.CloseButtonIsDisabled)
    		this.DisableCloseButton();
    	base.OnSizeChanged(e);
    }
    
    #endregion
