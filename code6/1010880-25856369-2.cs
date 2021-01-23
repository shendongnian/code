    public partial class AppDelegate: UIApplicationDelegate
    {
        public static bool IsInDesignerView = true;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            IsInDesignerView = false;
            return true;
        }
    }
