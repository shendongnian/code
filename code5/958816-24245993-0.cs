    private int _DeviceID;
    public int DeviceID
        {
            get
            {
    
              return _DeviceID;
                
            }
    
            set
            {
              _DeviceID = value;
              OnPropertyChanged("DeviceID");
            }
