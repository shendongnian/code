        private DataTable _dataTable;
        public DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._dataTable = new DataTable("table");
            this._dataTable.Columns.Add("col0");
            this._dataTable.Columns.Add("col1");
            this._dataTable.Columns.Add("col2");
            this._dataTable.Rows.Add("data00", "data01", "data02");
            this._dataTable.Rows.Add("data10", "data11", "data22");
            this._dataTable.Rows.Add("data20", "data21", "data22");
            this.grid1.DataContext = this;
            
        }
