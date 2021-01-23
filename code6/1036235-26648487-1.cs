     public double longtitude // Here change to Longitude
        {
            get { return this.lonValue; }
            set
            {
                if (value != this.lonValue)
                {
                    this.lonValue = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }
     private double latValue;
        public double latitude // Change to Latitude
        {
            get { return latValue; }
            set
            {
                if (value != this.latValue)
                {
                    this.latValue = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }
