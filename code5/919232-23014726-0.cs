    UITableViewController _parent;
    
    public RootTableSource (IEnumerable<VendorDetails> items, UITableViewController parent)
    {
        tableItems = items.ToList (); 
        _parent = parent;
    }
    
    
    public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
    {
        tableView.DeselectRow (indexPath, true); 
    
        _parent.NavigationController.PushViewController(...);
    }
