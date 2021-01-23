    public class CategoryViewController : UITableViewController, IAdMarvelDelegate
    {
        [Export ("getAdSucceeded")]
        public void GetAdSucceeded()
        {
            Console.WriteLine("succeeded!");
        }
        [Export("getAdFailed")]
        public void GetAdFailed()
        {
            Console.WriteLine("failed!"); 
            AppDelegate.Shared.AddAdBanner();
        }
    }
