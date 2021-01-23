    private SomeType _someProperty = null;
    public SomeType SomeProperty
    {
        get
        {
            if (_someProperty == null)
                _someProperty = DataService.GetPropertyInfo();
            return _someProperty;
        }
    }
