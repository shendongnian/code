    public class SomethingViewModel : INotifyPropertyChanged
    {
        private string _prefix;
        private string _postfix;
        public SomethingViewModel()
        {
            Sources = new ObservableCollection<string>(/*pass initial data of the list*/);
            Sources.CollectionChanged += (sender, args) => OnPropertyChanged("Items");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<string> Sources { get; set; }
        public IList<string> Items
        {
            get { return Sources.Select(x => string.Format("{0}{1}{2}", Prefix, x, Postfix)).ToList(); }
        }
        public string Prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                if (_prefix == value) return;
                _prefix = value;
                OnPropertyChanged("Prefix");
                OnPropertyChanged("Items");
            }
        }
        public string Postfix
        {
            get
            {
                return _postfix;
            }
            set
            {
                if (_postfix == value) return;
                _postfix = value;
                OnPropertyChanged("Postfix");
                OnPropertyChanged("Items"); // we will notify that the items list has changed so the view refresh its items
            }
        }
    }
