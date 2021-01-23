    public MyItemViewModel SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            if (value.IsSelected)
            {
                this.SetProperty(ref _selectedItem, value);
            }
            // Optional: if you require
            else
            {
                this.SetProperty(ref _selectedItem, null);
            }            
        }
    }
