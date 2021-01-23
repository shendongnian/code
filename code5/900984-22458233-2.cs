    public decimal Value
    {
        get { return Value; }
        set { Value = Math.Round(value, 2, MidpointRounding.ToEven); }
    }
