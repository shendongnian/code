    public string MyProperty{get;set;}
    public bool MyPropertyChecked
    {
        get { return !MyProperty.Equals('Steve')}
    }
