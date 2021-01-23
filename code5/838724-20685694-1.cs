    public class MyType : INotifyPropertyChanged
    {
        private ObservableCollection<Key> _command = new ObservableCollection<Key>();
        private string _commandsString = String.Empty;
        public ObservableCollection<Key> Command
        {
            get { return _command; }
        }
        public string CommandsString
        {
            get { return _commandsString; }
            set 
            { 
                _commandsString = value;
                OnPropertyChanged("CommandsString");
            }
        }
        public MyType()
        {
            _command.CollectionChanged += _command_CollectionChanged;
        }
        void _command_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_command.Count == 0)
                CommandsString = String.Empty;
            else
                CommandsString = " " + string.Join("+", _command);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
