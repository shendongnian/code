    class MyContainer : ContainerControl
    {
    	protected override System.Drawing.Point ScrollToControl(Control activeControl)
    	{
    		return base.AutoScrollPosition;
    	}
    }
