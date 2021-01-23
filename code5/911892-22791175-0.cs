    private _bookings ObservableCollection<Booking>;
    public ObservableCollection<Booking> Bookings
    {
        get { return _bookings; }
        set
        {
            _bookings = value;
            OnPropertyChanged("Bookings");
            OnPropertyChanged("Requested");
            OnPropertyChanged("Available");        
        }
    }
