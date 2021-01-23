     public ObservableCollection<string> DHCPoolName
        {
            get
            {
                return dhcppoolname;
            }
            set
            {
                dhcppoolname = value;
                OnPropertyChanged("DHCPoolName");
            }
        }
