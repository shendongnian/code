     private YourRowType  _selectedItem ;
        public YourRowType SelectedItem 
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem == value)
                {
                    return;
                }
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }
