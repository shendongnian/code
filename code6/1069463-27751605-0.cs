    public MyCoolClass
    {
        private ObservableCollection<Roll> _rollList;
        public ObservableCollection<Roll> RollList
        {
            get { return _rollList; }
            set
            {
                if (_rollList != value)
                {
                    _rollList = value;
                    OnPropertyChanged("RollList");
                }
            }
        }
    }
