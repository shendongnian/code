    class Data, INotifyPropertyChanged
    {
         private BitmapImage _cover;
         public BitmapImage Cover
         {
            get { return _cover; }
            set 
            { 
                _cover = value;
                OnPropertyChanged("Cover");
            }
         }
    
        public string Title{ get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
