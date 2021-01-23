    public class CustomDialogViewController : DialogViewController
    {
        public CustomDialogViewController (RootElement root) : base (root) {}
    
        public override Source CreateSizingSource (bool unevenRows)
        {
            return new CustomSource(this);
        }
    
        private class CustomSource : DialogViewController.Source
        {
            public CustomSource (CustomDialogViewController controller) : base (controller)
            {}
    
            public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
                // You handle row selected here
                base.RowSelected (tableView, indexPath);
            }
        }
    }
