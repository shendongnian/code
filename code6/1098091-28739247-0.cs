    partial class MainMenuTableViewController : UITableViewController
	{
		public MainMenuTableViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.TableView.Delegate = new MainMenuTableViewDelegate (this); //this is the important part. Here I set a custom delegate class for the TableView. I pass the current TableViewController as a parameter in the constructor so I can call the NavigationController from the delegate class to push my custom MonoTouch DialogViewController onto the navigation stack
		}
	}
