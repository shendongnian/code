    private DateTime _dob;
    public DateTime DateOfBirth
    {
        get
        {
            return _dob;
        }
        private set
        {
            _dob = value;
            OnPropertyChanged();
        }
    }
    
    [DependsOnProperty("DateOfBirth")]
    public int Age
    {
        get
        {
            return DateTime.Today.Year - _dob.Year;
        }
    }
