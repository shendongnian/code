    public string Property
    {
        set
        {
            _property = value;
            var task = AMethodAsync();
        }
    }
