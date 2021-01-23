    public class Filter : NotifyPropertyChangedBase
    {
        public event EventHandler OnEnabledChanged;
        public string Genre { get; set; }
        private bool _IsEnabled;
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set 
            { 
                _IsEnabled = value;
                OnPropertyChanged();
                if (OnEnabledChanged != null)
                    OnEnabledChanged(this, new EventArgs());
            }
        }
        public Filter(string genre)
        {
            this.Genre = genre;
        }
    }
    public class Movie
    {
        //We don't need to implement INotifyPropertyChanged here
        //because these values will never change.
        public string Name { get; set; }
        public string Genre { get; set; }
    }
