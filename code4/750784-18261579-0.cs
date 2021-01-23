	public class MyViewController : UITableViewController {
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.TableView.Source = new ViewSource(this);
		}
		public class ViewSource : UITableViewSource
		{
			public override int RowsInSection (UITableView tableview, int section)
			{
				return 100;
			}
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				return new UITableViewCell (UITableViewCellStyle.Default, "foo");
			}
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var n = AppDelegate.window.RootViewController as UINavigationController;
				n.PushViewController (new MyViewController (), true);
				GC.Collect ();
			}
			MyViewController _parentController;
			public ViewSource(MyViewController parentController)
			{
				_parentController = parentController;
			}
		}
		~MyViewController ()
		{
			Console.WriteLine ("Disposing");
		}
	}
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public static UIWindow window;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var myViewController = new MyViewController ();
			window.RootViewController = new UINavigationController (myViewController);
			window.MakeKeyAndVisible ();
			return true;
		}
	}
