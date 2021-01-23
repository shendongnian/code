            MainScreen controller;
    		UINavigationController navcontroller;
    
    		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    		{
    		
    			// create a new window instance based on the screen size
    			window = new UIWindow (UIScreen.MainScreen.Bounds);
    			controller = new MainScreen ();
    
    			var initialControllers = new List<UIViewController>();
    			initialControllers.Add (controller);
    			  
    			navcontroller = new UINavigationController ();
    			navcontroller.ViewControllers = initialControllers.ToArray ();
    			window.RootViewController = navcontroller;
    			window.MakeKeyAndVisible ();
    			return true;
    		}
