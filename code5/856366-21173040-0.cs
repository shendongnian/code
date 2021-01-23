    public DateTime Date
    {
        get
        {
            return _criticalDate.Date;
        }
        set
        {
            if (_criticalDate.Date != value)
            {
                if (_criticalDate != null && value != null && _criticalDate.Date == value)
                   return;
                _criticalDate.Date = value;
                OnPropertyChanged("Date");
            }
        }
    }
