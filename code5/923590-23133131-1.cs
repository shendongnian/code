    public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
    {
        UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);   
        if (cell == null)
           cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
        if(indexPath.Section == 0)
        {
            cell.TextLabel.Text = today_emails[indexPath.Row];
        }
        else if(indexPath.Section == 1)
        {
            cell.TextLabel.Text = yesterday_emails[indexPath.Row];
        }
        else
        {
            cell.TextLabel.Text = other_emails[indexPath.Row];
        }
        
        return cell;
    }
