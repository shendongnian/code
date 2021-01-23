    public TopGridItem SelectedItem 
    {
        get { return _selectedItem; }
    
        set
        {
            _selectedItem = value;
            OnPropertyChanged("SelectedItem");
    
            if (_selectedItem != null)
            _selectedItem.MyCollectionView.Refresh();
        }
    }
