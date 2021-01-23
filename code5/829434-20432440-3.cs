    public class ImageSourceModel : INotifyPropertyChanged
    {
        public string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (value == _imageSource)
                    return;
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
