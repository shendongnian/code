    public class NavigationTableSource : UITableViewSource
    {
        private readonly IList<ChapterViewModel> _chapters;
        private const string CellIdentifier = "NavigationCell";
        public NavigationTableSource(IList<ChapterViewModel> chapters)
        {
            _chapters = chapters;
        }
        public override int RowsInSection(UITableView tableview, int section)
        {
            return _chapters.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // todo: This is where we're going to load up the appropriate chapter.
            new UIAlertView("Row Selected", _chapters[indexPath.Row].Title, null, "OK", null).Show();
        }
        
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) ??
                       new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            // if there are no cells to reuse, create a new one
            cell.TextLabel.Text = _chapters[indexPath.Row].Title;
            return cell;
        }
    }
