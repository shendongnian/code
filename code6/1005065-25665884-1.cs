	public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
	{
		tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		if (this.controller.BLevelSelected != null) {
			this.controller.BLevelSelected (this, new BLevelSelectedEventArgs (controller.bLevelList[indexPath.Row]));
		}
	}
