    public string AddressLine1
    {
        get
        {
            // Use the first non-null element.
            return _addr.Where(x => x != null).FirstOrDefault();
        }
    }
    public string AddressLine2
    {
        get
        {
            // Use the second non-null element.
            return _addr.Where(x => x != null).Skip(1).FirstOrDefault();
        }
    }
    public string AddressLine3
    {
        get
        {
            // Use the third non-null element.
            return _addr.Where(x => x != null).Skip(2).FirstOrDefault();
        }
    }
