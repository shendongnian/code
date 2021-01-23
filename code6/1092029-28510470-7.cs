    partial class AViewController : UIViewController
     {
      public override void ViewWillAppear(bool animated)
	   {
        NSUserDefaults.StandardUserDefaults.RegisterDefaults (appDefaults);
       	NSUserDefaults.StandardUserDefaults.Synchronize ();
        var username = NSUserDefaults.StandardUserDefaults.StringForKey ("username");
	    Console.WriteLine (username);
        }
    }
