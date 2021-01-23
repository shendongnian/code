    public class Movie : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }                
            }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                if (_info != value)
                {
                    _info = value;
                    RaisePropertyChanged("Info");
                }                
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
