     public DataGridCellInfo SelectedCell
        {
            get
            {
                return _selectedCell;
            }
            set
            {
                _lastCell = _selectedCell; //here is my edit
                _selectedCell = value;
                OnPropertyChanged("SelectedCell");
            }
        }
