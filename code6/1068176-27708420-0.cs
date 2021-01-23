        private BitmapImage _ImageSource = null;
        public object _originalImageSource= null;
        public object ImageSource
        {
            get { return this._ImageSource; }
            set
            {
                this._originalImageSource = value;
                if (this._ImageSource != value)
                {
                    this._ImageSource = value is BitmapImage ? (BitmapImage)value : 
                        value is Uri ?
                        new BitmapImage(value as Uri) :
                        new BitmapImage(new Uri(value.ToString()));
                    this.RaisePropertyChanged("ImageSource");
                }
            }
        }
