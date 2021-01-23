     private Uri _photo;
        public Uri Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                RaisePropertyChanged("Photo");
            }
        }
