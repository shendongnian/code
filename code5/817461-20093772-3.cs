    private DataGridCellInfo _cellInfo;
    public DataGridCellInfo CellInfo
    {
        get { return _cellInfo; }
        set
        {
            _cellInfo = value;
            OnPropertyChanged("CellInfo");
            MessageBox.Show(string.Format("Column: {0}",
                            _cellInfo.Column.DisplayIndex != null ? _cellInfo.Column.DisplayIndex.ToString() : "Index out of range!"));
        }
    }
