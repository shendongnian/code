    public class TableSource<T> : UITableViewSource where T : new()
    {
         public TableSource(List<T> list) 
         {
         }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            throw new NotImplementedException();
        }
        public override int RowsInSection(UITableView tableview, int section)
        {
            throw new NotImplementedException();
        }
    }
