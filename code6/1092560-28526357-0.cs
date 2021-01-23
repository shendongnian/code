    private PERFCONTENEUR _selectedCustomer;
        public PERFCONTENEUR SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    NotifyPropertyChanged("SelectedCustomer");
                }
            }
        }
