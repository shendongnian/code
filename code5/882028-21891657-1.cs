        private BitmapImage _TheImage;
        public BitmapImage TheImage
        {
            get { return _TheImage; }
            set { _TheImage = value; OnPropertyChanged("TheImage"); }
        }
