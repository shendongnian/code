    private ObservableCollection<string> dhcppoolname;
     public ObservableCollection<string> DHCPoolName
        {
            get
            {
                if(dhcppoolname == null)
                {
                    dhcppoolname = new ObservableCollection<string>();
                }
                return dhcppoolname;
            }
            set
            {
                dhcppoolname = value;
                OnPropertyChanged("DHCPoolName");
            }
        }
