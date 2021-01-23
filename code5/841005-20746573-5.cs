    public ProductHistory SelectedItem
    {
        get { return _SelectedItem; }
        set
        {
            if (_SelectedItem != value)
            {
                _SelectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
                RaisePropertyChanged(() => IsGridEnabled);
            }
        }
    }
