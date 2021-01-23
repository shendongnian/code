    //User control
    
    public event CancelEventHandler BeginEdit;
    public event EventHandler EndEdit;
    
    
    private btnYourButton_Click(object sender, EventArgs e)
    {
    	CancelEventArgs e = new CancelEventArgs();
    	e.Cancel = false;
    	if (BeginEdit != null)
    		BeginEdit(this, e);
    	if (e.Cancel == false)
    	{
    		if (EndEdit != null)
    			EndEdit(this, new EventArgs);
    			
    		//You can place your code here to disable controls
    	}
    }
