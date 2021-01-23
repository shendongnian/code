    private DateTime _myDate;
    public DateTime MyDate
    {
        get { return _myDate; }
        set { _myDate = DateTime.SpecifyKind(value, DateTimeKind.Unspecified); }
    }
