    private volatile bool isUserScroll = true;
    public bool IsAutoScrollEnabled { get; set; }
    
    // Items is the collection with the items displayed in the ListView
    		
    private void DoAutoscroll(object sender, EventArgs e)
    {
    	if(!IsAutoScrollEnabled)
    		return;
    	var lastItem = Items.LastOrDefault();
    	if (lastItem != null)
    	{
    		isUserScroll = false;
    		logView.ScrollIntoView(lastItem);
    	}
    }
    
    private void scrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
    	if (e.VerticalChange == 0.0)
    		return;
    
    	if (isUserScroll)
    	{
    		if (e.VerticalChange > 0.0)
    		{
    			double scrollerOffset = e.VerticalOffset + e.ViewportHeight;
    			if (Math.Abs(scrollerOffset - e.ExtentHeight) < 5.0)
    			{
    				// The user has tried to move the scroll to the bottom, activate autoscroll.
    				IsAutoScrollEnabled = true;
    			}
    		}
    		else
    		{
    			// The user has moved the scroll up, deactivate autoscroll.
    			IsAutoScrollEnabled = false;
    		}
    	}
    	isUserScroll = true;
    }
