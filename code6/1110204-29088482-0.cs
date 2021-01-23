    public DataGridCellInfo SelectedCellInfo
    {
        get { return _selectedCellInfo; }
        set
        {
            _selectedCellInfo = value;
            OnPropertyChanged("SelectedCellInfo");
            _columnName = _selectedCellInfo.Column.Header;
        }
    }
