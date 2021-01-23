    class GridViewModel 
    {
        //bind grid's DataSource to Rows collection
        public ObservableCollection<RowViewModel> Rows { get;private set; }
        public void AddNewRow() 
        {
            Rows.Add(new RowViewModel { IsEditing =true});
        }
    }
