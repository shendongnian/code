    public int SelectedItem
    {
        get 
        { 
            return _selecteditem; 
        }
        set 
        {
            if (_selectedItem != value)
            {
                 _selectedItem = value;
                 RaisePropertyChanged("SelectedItem");
                 UpdateGridData(); 
            }
        }
    }
