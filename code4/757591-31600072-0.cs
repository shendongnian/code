        public DataView DataView
        {
            get { return _dataView; }
            set
            {
                _dataView = value;
                OnPropertyChanged("DataView");
            }
        }
