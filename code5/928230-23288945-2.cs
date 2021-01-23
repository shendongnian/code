    public ObservableCollection<DateTime> AvailableDates
    {
        get { return availableDates; }
        set { availableDates = value; NotifyPropertyChange("AvailableDates"); }
    }
