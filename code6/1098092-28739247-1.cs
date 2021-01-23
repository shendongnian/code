		public class MainMenuTableViewDelegate : UITableViewDelegate
		{
			private UITableViewController _parentController;
			public MainMenuTableViewDelegate(UITableViewController parentController) : base()
			{
				_parentController = parentController;
			}
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				if (indexPath.Row == 2) {					
					_parentController.NavigationController.PushViewController (new AccountDialogViewController(), true);
				}
			}
		}
