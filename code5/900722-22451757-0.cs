		public class TableSource : MvxSimpleTableViewSource
		{
			private TwitterView _parent;
			public TableSource (UITableView tableView, TwitterView parent)
				: base(tableView, TweetCell3.Identifier, TweetCell3.Identifier)
			{
			    _parent = parent;
				tableView.RegisterNibForCellReuse(UINib.FromName(TweetCell3.Identifier, NSBundle.MainBundle), TweetCell3.Identifier);
			}
			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				return _parent.SomeMethod(indexPath);
			}
		}
