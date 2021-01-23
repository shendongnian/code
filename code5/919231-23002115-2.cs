        UIWindow window;
        HomeScreen home;
        public static UINavigationController navigation;
        //set navigation public and static		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			home = new HomeScreen ();
			navigation = new UINavigationController(home);
			window.RootViewController =  navigation;
			window.MakeKeyAndVisible ();
			return true;
		}
	}
