    private SomeData _data1;
    public SomeData Data1 {
        get { return _data1; }
        set {
            _data1 = value;
            AddChild(_data1);
        }
    }
