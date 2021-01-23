        private string _yourProperty;
        public string YourProperty
        {
            get { return _yourProperty; }
            set
            {
                if (_yourProperty == value) return;
                _yourProperty = value;
                OnPropertyChanged("YourProperty");
                OnPropertyChanged("YourImageSource");
            }
        }
        //this code is just for demo.
        public BitmapImage YourImageSource
        {
            get
            {
                return new BitmapImage(BuildUriFromYourProperty());
            }
        }
