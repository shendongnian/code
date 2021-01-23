    public TopGridItem SelectedItem 
    {
        get { return _selectedItem; }
    
        set
        {
            _selectedItem = value;
            OnPropertyChanged("SelectedItem");
    
            // _dataGrid - link to BottomDataGrid  
            _dataGrid.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            
        }
    }
