    public class MediaFile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs("propertyName"));
            }
        }
        private bool hasVideo
        public bool HasVideo
        {
            get { return hasVideo; }
            set
            {
                 hasVideo = value;
                 OnPropertyChanged("HasVideo"); 
            }
        }
        // other properties
   }
