    private string _myProp;
    public MyProp
    {
        get { return _myProp ?? GetValueFromMethod(); }
        set { _myProp = value; }
    }
