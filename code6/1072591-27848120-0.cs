    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
           TableCell cell = tableView.DequeueReusableCell("YourIdentifier") ?? new TableCell();
           cell.IndexPath = indexPath;
           return cell;
        }
