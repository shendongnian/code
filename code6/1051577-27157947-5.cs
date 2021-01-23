    #region ResizeWindows
    bool ResizeInProcess = false;
    private void Resize_Init(object sender, MouseButtonEventArgs e)
    {
    	Rectangle senderRect = sender as Rectangle;
    	if (senderRect != null)
    	{
    		ResizeInProcess = true;
    		senderRect.CaptureMouse();
    	}
    }
    
    private void Resize_End(object sender, MouseButtonEventArgs e)
    {
    	Rectangle senderRect = sender as Rectangle;
    	if (senderRect != null)
    	{
    		ResizeInProcess = false; ;
    		senderRect.ReleaseMouseCapture();
    	}
    }
    
    private void Resizeing_Form(object sender, MouseEventArgs e)
    {
    	if (ResizeInProcess)
    	{
    		Rectangle senderRect = sender as Rectangle;
    		Window mainWindow = senderRect.Tag as Window;
    		if (senderRect != null)
    		{
    			double width = e.GetPosition(mainWindow).X;
    			double height = e.GetPosition(mainWindow).Y;
    			senderRect.CaptureMouse();
    			if (senderRect.Name.ToLower().Contains("right"))
    			{
    				width += 5;
    				if (width > 0)
    					mainWindow.Width = width;
    			}
    			if (senderRect.Name.ToLower().Contains("left"))
    			{
    				width -= 5;
    				mainWindow.Left += width;
    				width = mainWindow.Width - width;
    				if (width > 0)
    				{
    					mainWindow.Width = width;
    				}
    			}
    			if (senderRect.Name.ToLower().Contains("bottom"))
    			{
    				height += 5;
    				if (height > 0)
    					mainWindow.Height = height;
    			}
    			if (senderRect.Name.ToLower().Contains("top"))
    			{
    				height -= 5;
    				mainWindow.Top += height;
    				height = mainWindow.Height - height;
    				if (height > 0)
    				{
    					mainWindow.Height = height;
    				}
    			}
    		}
    	}
    }
    #endregion
