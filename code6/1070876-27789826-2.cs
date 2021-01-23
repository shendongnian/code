    public DateTime? DateFrom
    {
        get { return _dateFrom; }
        set
        {
            _dateFrom = value;
            RaisePropertyChanged("DateFrom");
            RefreshProducts();
        }
    }
    public DateTime? DateTo
    {
        get { return _dateTo; }
        set
        {
            _dateTo = value;
            RaisePropertyChanged("DateTo");
            RefreshProducts();
        }
    }
    private void SetThisWeek()
    {
        _dateFrom = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        RaisePropertyChanged("DateFrom");
        _dateTo = DateTime.Today.AddDays(6-(int)DateTime.Today.DayOfWeek);
        RaisePropertyChanged("DateTo");
        RefreshProducts();
    }
