	public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
		tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		if (this.controller.Delegate != null) {
			this.controller.Delegate.SetItems (this.controller.items[indexPath.Row]);
		}
	}
	// a method in MasterViewController
	public void SetItems(string items){
		this.items = items;
		this.NavigationController.PopViewControllerAnimated (true);
		// do something here
	}
