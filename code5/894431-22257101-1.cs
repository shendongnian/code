    private double _MinValue, _MaxValue; // no readonly keyword
    public ValidateCustomAttribute(double min, double max, Func<string> errorMessageAccessor)
        : base(errorMessageAccessor)
    {
        _MinValue = min;
        _MaxValue = max;
    }
