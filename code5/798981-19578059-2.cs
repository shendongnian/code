        private ObservableCollection<Departure> _departures;
        public ObservableCollection<Departure> Departures
        {
            get
            {
                return _departures
            }
            set
            {
                _departures = value;
                OnPropertyChanged("Departures");
            }
        }
