    private DateTime _StartDate;
    public DateTime StartDate
    {
        get { return _StartDate; }
        set
        {
            if (value > _EndDate)
            {
                throw new MyEventException("Start date is not supposed to be greater than end date.");
            }
            else
            {
                _StartDate = value;
            }
        }
    }
    private DateTime _EndDate;
    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
