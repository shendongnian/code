    private string _MyClassProp;
    public string MyClassProp
    {
        get { return _MyClassProp; }
        set
        {
            _MyClassProp = value;
            MyDictValue = MyDictionary[MyClassProp].MyObjValue;
            Notify("MyClassProp");
        }
    }
