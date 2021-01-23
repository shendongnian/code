    private readonly Statistics _statistics;
    public int ReservationCount
    {
        get { return _statistics.ReservationCount; }
        set
        {
            _statistics.ReservationCount = value;
            OnPropertyChanged("ReservationCount");
        }
    }               
    public PartyStatsControlViewModel(Statistics statistics)
    {
        _statistics = statistics;
        _statistics.ReservationCountChanged += OnReservationCountChanged;
    }
    private void OnReservationCountChanged(object sender, RoutedEventArgs args)
    {
        // todo: force this onto the UI thread or exceptions will occur
        this.ReservationCount = ((Statistics)sender).ReservationCount;
    }
