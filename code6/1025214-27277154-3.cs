    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate, ILoginManager, IAppNavigation
    {
        // class-level declarations
        UIWindow window;
      
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.RootViewController = App.GetShowSplashPage(this).CreateViewController();
           
            window.MakeKeyAndVisible();
            return true;
        }
        public void GetMainMenu()
        {
            window.RootViewController = App.GetMainMenu().CreateViewController();
            window.MakeKeyAndVisible();
        }
        public void GetLoginPage()
        {
            window.RootViewController = App.GetLoginPage(this).CreateViewController();
            window.MakeKeyAndVisible();
        }
              
       
       
