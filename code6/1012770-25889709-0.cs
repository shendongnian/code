		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath){
			// your criteria here
			if (read) {
				var cell = (UnreadCell)tableView.DequeueReusableCell (UnreadCell.cellIdentifier);
				cell.UpdateCell (...);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.SeparatorInset = UIEdgeInsets.Zero;
				return cell;
			} else {
				var cell = (ReadCell)tableView.DequeueReusableCell (ReadCell.cellIdentifier);
				cell.UpdateCell (...);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.SeparatorInset = UIEdgeInsets.Zero;
				return cell;
			}
		}
