    // class level variable
    NSObject observer;
    
    // register as observer
    public override void ViewWillAppear (bool animated)
    {
    	base.ViewWillAppear (animated);
    	observer = NSNotificationCenter.DefaultCenter.AddObserver ((NSString)UIDevice.OrientationDidChangeNotification, OrientationChanged);
    }
    
    // deregister as observer
    public override void ViewDidDisappear (bool animated)
    {
    	base.ViewDidDisappear (animated);
    	if (observer != null) { 
    		NSNotificationCenter.DefaultCenter.RemoveObserver (observer);
    		observer = null;
    	}
    }
    
    // function which should do something when notification is received
    public void OrientationChanged(NSNotification notification){
    	Console.WriteLine ("test");
    	// perhaps you can do the following as in the linked SO question: NSObject myObject = notification.Object;
    }
