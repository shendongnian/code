      public class TabItem
    {
        public String Header { get; set; }
        public String Content { get; set; }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TabItem> _tabItems;
        public ObservableCollection<TabItem> TabItems
        {
            get
            {
                return _tabItems;
            }
            set
            {
                if (_tabItems == value)
                {
                    return;
                }
                _tabItems = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand _addNewTabCommand;
        public RelayCommand AddNewTabCommand
        {
            get
            {
                return _addNewTabCommand
                    ?? (_addNewTabCommand = new RelayCommand(
                    () =>
                    {
                        TabItems.Add(new TabItem()
                        {
                            Header = "NewTab",
                            Content = "NewContent"
                        });
                    }));
            }
        }
        private RelayCommand<TabItem> _closeTabCommand;
        public RelayCommand<TabItem> CloseTabCommand
        {
            get
            {
                return _closeTabCommand
                    ?? (_closeTabCommand = new RelayCommand<TabItem>(
                    (t) =>
                    {
                        TabItems.Remove(t);
                    }));
            }
        }
        public MainViewModel()
        {
            TabItems = new ObservableCollection<TabItem>()
           {
                new TabItem()
               {
                   Header = "Home",
                   Content = "Home Content"
               },
               new TabItem()
               {
                   Header = "Header1",
                   Content = "Content1"
               }
           };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
