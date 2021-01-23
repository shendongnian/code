    #pragma warning disable 4014
    public string Property
    {
        set
        {
            _property = value;
            AMethodAsync();
        }
    }
    #pragma warning restore 4014
