    public MyProp
    {
        get { return IsNullOrEmpty(_myProp) ? GetValueFromMethod() : _myProp; }
        set { _myProp = value; }
    }
