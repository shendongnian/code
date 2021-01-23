    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }
    }
    public ProductHistory SelectedItem
    {
        get { return _SelectedItem; }
        set
        {
            if (_SelectedItem != value)
            {
                _SelectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
            IsSelected = value != null;
        }
    }
