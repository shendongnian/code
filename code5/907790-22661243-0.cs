    public string PropertyA
    {
        get { ... }
        set
        {
            _propertyA = value;
            if (value != null)
                YourSortOrder = int.Parse(value.Substring(0, value.IndexOf("_", StringComparison.InvariantCultureIgnoreCase)));
        }
    }
