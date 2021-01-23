    public NameModelClass SelectedCustomer
        {
        get { return _selectedCustomer; }
        set
            {
            if (_selectedCustomer != value)
                {
                _selectedCustomer = value;
                LastName = value.LastName;
                OnPropertyChanged("SelectedCustomer");
                OnPropertyChanged("LastName");   //<-- new 
                }
            }
        }
