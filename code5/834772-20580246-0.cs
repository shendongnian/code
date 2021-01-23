     private double? b;
        public double? B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("B"));
                }
            }
        }
