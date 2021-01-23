    private DateTime? _DateTimeProperty;
    public DateTime? DateTimeProperty
    {
        get
        {
            return _DateTimeProperty;
        }
        set
        {
            _DateTimeProperty = value.ToKindUtc();
        }
    }
