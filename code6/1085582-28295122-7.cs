    class RowViewModel
    {
        GridViewModel parent;
        public RowViewModel(GridViewModel parent)
        {
            this.parent = parent;
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Value { get; set; }
        public bool IsEditing 
        {
            get { return this == parent.ActiveRow; }
            set 
            { 
                if (value) 
                    parent.ActiveRow = this;
                NotifyChange();
            }
        } 
    }
    class GridViewModel  
    {  
        private RowViewModel activeRow;  
        public ObservableCollection<RowViewModel> Rows { get; private set; }
        
        public GridViewModel()
        {
            Rows = new ObservableCollection<RowViewModel>();
        }
    
        public void AddNewRow()
        {
            Rows.Add(new RowViewModel(this) { IsEditing = true });
        }
    
        public RowViewModel ActiveRow 
        {
            get { return activeRow;}
            set 
            {
                activeRow = value;
                foreach (var row in Rows.Except(new[] { activeRow })) 
                {
                    row.IsEditing = false;
                }
            }
        }
    }
