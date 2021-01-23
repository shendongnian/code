    // We use params T[] here to reduce the need for any calling code to declare,
    // for example, a List<int>, which would later need to potentially be changed in
    // many places.
    public void SetEnumerable(params T[] value)
    {
        _en = value;
    }    
