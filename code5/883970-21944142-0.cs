    internal class MainViewModel : INotifyPropertyChanged
    {
        private List<string> _selectedItems;
        public MainViewModel()
        {
            MenuCommand = new MenuCommand();
            StringItems = new List<string>();
            StringItems.Add("Hello");
            StringItems.Add("world");
            StringItems.Add("of");
            StringItems.Add("mysterious");
            StringItems.Add("WPF");
        }
        public List<string> StringItems { get; set; }
        public MenuCommand MenuCommand { get; private set; }
        public string MenuCommandTitle
        {
            get { return "Selected items: " + SelectedItems.Aggregate((a, b) => a + ", " + b); }
        }
        public List<string> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                OnPropertyChanged("MenuCommandTitle");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
