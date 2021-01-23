      private BitmapImage image = null;
        public BitmapImage Chart
        {
            get
            {
                return image;
            }
            set
            {
                if (value != image)
                {
                    image = value;
                    NotifyPropertyChanged("Chart");
                }
                
            }
        }
