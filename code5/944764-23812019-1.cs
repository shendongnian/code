    public object this[ string key ]
    {
        get
        {
            return coll[ key ];
        }
        set
        {
            coll[ key ] = value;
        }
    }
