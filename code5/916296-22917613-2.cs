    private readonly bool _boolValue;
    public bool SafeProperty { get { return _boolValue; } }
    public ObjectType(bool initialValue) {
        _boolValue = initialValue;
    }
