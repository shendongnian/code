    public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
    {
         NSNotificationCenter.DefaultCenter.PostNotification (NSNotification.FromName ("OpenMyFile", url));
         return true;
    }
