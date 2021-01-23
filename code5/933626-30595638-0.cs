    Timer singleClickTimer = new Timer();
    
    private void trayIcon_MouseClick(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		// Give the double-click a chance to cancel this
    		singleClickTimer.Interval = (int) (SystemInformation.DoubleClickTime * 1.1);
    		singleClickTimer.Start();
    	}
    }
    
    private void singleClickTimer_Tick(object sender, EventArgs e)
    {
    	singleClickTimer.Stop();
    
    	// do single click here
    }
    
    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		// Cancel the single click
    		singleClickTimer.Stop();
    
    		// do double click here
    	}
    }
