    public string TestMessage
    {
        get { return testMessage; }
        set
        {
            testMessage = value;
            OnPropertyChanged("TestMessage");
        }
    }
