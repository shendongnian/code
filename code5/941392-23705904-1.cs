    private DataObject _data;
    public void Initialize(DataObject data)
    {
        _data = data;
    }
    public void DoSomething() //Just an arbitrary method using the data
    {
        return _data.B + " " + _data.A.ToString();
    }
