    public DateTime TrialDate
    {
        get { return _intro.TrialDate; }
        set
        {
            _intro.TrialDate = value;
            OnPropertyChanged("TrialDate");
            OnPropertyChanged("Error");
        }
    }
    public string Error
    {
        get { return this["TrialDate"]; }
    }
