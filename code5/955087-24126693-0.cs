    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        var item = data[indexPath.Row];
    
        HelloViewController helloView = new HelloViewController(item);
        AppDelegate appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
        appDelegate.RootNavigationController.PushViewController(helloView, true);
    }
