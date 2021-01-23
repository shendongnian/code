    public class LookupEntity : INotifyPropertyChanged
    {
        private bool _isInactive;
        public bool IsSelected { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsInactive
        {
            get { return _isInactive; }
            set
            {
                _isInactive = value;
                OnPropertyChanged("IsInactive");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
