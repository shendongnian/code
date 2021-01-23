    public DateTime? MyDateTime
    {
        get { return _myDateTime; }
    }
    private DateTime? _myDateTime;
    public DateTime? MyDateOnly
    {
        get 
        { 
            if (MyDateTime == null) return null;
            return MyDateTime.Value.Date; 
        }
    }
