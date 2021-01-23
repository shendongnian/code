    protected class ServiceTableSource : UITableViewSource
    {
        protected string[] _uuids;
        protected List<CBService> _services = new List<CBService> ();
        protected ServiceTableSource(List<CBService> services)
        {
             _services = services;
             //TODO: Add your logic here to create your string[] _uuids
        }
        protected const string cellID = "BleServiceCell";
        public event EventHandler<ServiceSelectedEventArgs> ServiceSelected = delegate {};
        public override int NumberOfSections (UITableView tableView)
        {
            //TODO: Use _services and/or _uuids to determine the number of sections
            return 1;
        }
        public override int RowsInSection (UITableView tableview, int section)
        {
            return _uuids.Length;
        }
        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell (cellID);
            CBService service = this._services [indexPath.Row];
            if (cell == null) {
                cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellID);
            }
            //TODO: Populate the cell with data from _services and/or _uuids.
            return cell;
        }
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            CBService service = this._services [indexPath.Row];
            this.ServiceSelected (this, new ServiceSelectedEventArgs (service));
            tableView.DeselectRow (indexPath, true);
        }
        public class ServiceSelectedEventArgs : EventArgs
        {
            public CBService Service {
                get { return this._service; }
                set { this._service = value; }
            }
            protected CBService _service;
            public ServiceSelectedEventArgs (CBService service)
            {
                this._service = service;
            }
        }
    }
