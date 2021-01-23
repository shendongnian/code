      public ObservableCollection<Device> DeviceList
        {
            get { return _DeviceList; }
            set { _DeviceList = value; NotifyPropertyChanged("DeviceList"); }
        }
        public ObservableCollection<Device> _DeviceList = new ObservableCollection<Device>();
