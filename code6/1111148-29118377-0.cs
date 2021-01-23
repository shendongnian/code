    private ObservableCollection<TableGuard> _ListGuards;
        public ObservableCollection<TableGuard> ListGuards
        {
            get { return _ListGuards; }
            set 
            { 
                _ListGuards = value;
                OnPropertyChanged("ListGuards");
            }
        }
