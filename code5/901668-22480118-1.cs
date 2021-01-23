     [Register ("AppDelegate")] 
     public partial class AppDelegate : UIApplicationDelegate {
         UIWindow window;   
         CompanyController cc;
         public override bool FinishedLaunching (UIApplication app, NSDictionary options)
         {     
            window = new UIWindow (UIScreen.MainScreen.Bounds);   
            cc = new CompanyController ();
            // If you have defined a root view controller, set it here:                   
            window.RootViewController = new UINavigationController (cc);
            // make the window visible     
            window.MakeKeyAndVisible ();
            return true;   
          } 
      }
