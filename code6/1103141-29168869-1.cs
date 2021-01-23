    protected override bool ProcessKeyPreview(ref Message m)
    {
    	if (m.Msg == Win32.WM_KEYDOWN && (Keys)m.WParam == Keys.Tab)
    	{
    		if (Control.ModifierKeys == Keys.Shift)
    		{
    			this.SelectNextControl(ActiveControl, false, true, true, true);  // Bring focus to previous control
    		}
    		else
    		{
    			this.SelectNextControl(ActiveControl, true, true, true, true);  // Bring focus to next control
    		}
    	}
    
    	return base.ProcessKeyPreview(ref m);
    }
