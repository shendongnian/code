    public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
    {
        UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);   
        if (cell == null)
           cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
        if(indexPath.Section == 0)
        {
            cell.TextLabel.Text = TodayEmails(_emailItems)[indexPath.Row].Subject;
        }
        else if(indexPath.Section == 1)
        {
            cell.TextLabel.Text = YesterdayEmails(_emailItems)[indexPath.Row].Subject;
        }
        else
        {
            cell.TextLabel.Text = OtherEmails(_emailItems)[indexPath.Row].Subject;
        }
        
        return cell;
    }
