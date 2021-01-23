    private decimal _Value;
    public decimal Value
    {
        get { return _Value; }
        set { _Value = Math.Round(value, 2, MidpointRounding.ToEven); }
    }
