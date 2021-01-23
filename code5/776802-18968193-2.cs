    public bool IsChecked
    {
        get
        {
            return _dataModel.MyCheckBox;
        }
        set
        {
            if(_dataModel != null)
            {
                _dataModel.MyCheckBox = value;
                OnPropertyChanged("IsChecked");
            }
            // Exception handling if _dataModel is null
        }
    }
