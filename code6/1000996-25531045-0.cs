    public Employee SelectedEmployee
    {
        get
        {
            return _selectedEmployee;
        }
        set
        {
            _selectedEmployee= value;
            RaisePropertyChanged("SelectedEmployee");
        }
    }
