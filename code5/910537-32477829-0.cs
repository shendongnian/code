    public string PropertyThing
    {
        get { return _myModel.PropertyThing; }
        set { _myModel.PropertyThing = value; PropChanged("PropertyThing"); }
    }
