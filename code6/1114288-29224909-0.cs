    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public IList SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
            }
        }
        private IList _selectedList;
        private List<StringValues> _bindStuffList;
        private object _lock = new object();
        public IEnumerable<StringValues> BindStuffList
        {
            get { return _bindStuffList; }
        }
        public MainWindowViewModel()
        {
            _bindStuffList = new List<StringValues>();
            BindingOperations.EnableCollectionSynchronization(_bindStuffList, _lock);
            BuildStuff();
        }
        private async void BuildStuff()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    _bindStuffList.Add(new StringValues { ID = "Item " + i });
                }
            });
            RaisePropertyChanged("BindStuffList");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(propertyName));
        }
    }
