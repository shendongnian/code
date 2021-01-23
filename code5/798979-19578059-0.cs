    private Station _currentStation;
        public Station CurrentStation
        {
            get
            {
                return _currentStation;
            }
            set
            {
                _currentStation = value;
                Departures = Departure.GetDepartures(CurrentStation);
                Console.WriteLine("New station selected: " + _currentStation.ToString());
                OnPropertyChanged("CurrentStation");
            }
        }
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
