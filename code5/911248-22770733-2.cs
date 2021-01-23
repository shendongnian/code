    private string _MyDictValue;
    public string MyDictValue
    {
        get { return _MyDictValue; }
        set
        {
            _MyDictValue = value;
            Notify("MyDictValue");
        }
    }
