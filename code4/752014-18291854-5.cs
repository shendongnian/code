	private void HandleHotkey()
	{
            // Do stuff...
	}
	 
	protected override void WndProc(ref Message m)
	{
	    if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
	        HandleHotkey();
	    base.WndProc(ref m);
	}
