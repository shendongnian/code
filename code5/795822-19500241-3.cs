    public void AddGotFocusEventHandler(Control.ControlCollection controls)
    {
    	foreach (Control ctrl in controls)
    	{
    		if(ctrl is TextBox)
    			ctrl.GotFocus += ctrl_GotFocus;
    
    		AddGotFocusEventHandler(ctrl.Controls);
    	}
    }
