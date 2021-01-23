    private void mainViewport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    	Point location = e.GetPosition(mainViewport);
    	try
    	{
                	ModelVisual3D result = (ModelVisual3D)GetHitTestResult(location);
    		//some code.......
    	}
    	catch
    	{
    		//some code .......
    	}
    }
