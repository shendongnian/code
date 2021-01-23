    public ObservableCollection<Departure> Departures
        {
            get
            {
                return Departure.GetDepartures(CurrentStation);
            }
            set
            {
                _departures = value; OnPropertyChanged("Departures")
            }
        }
