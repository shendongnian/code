    private DateTime _dob;
    
    // Field bind to your DataModel in the EDMX
    private SqlDateTime coreDob
    {
        get
        {
            if (_dob < SqlDateTime.MinValue)
                _dob = (DateTime)SqlDateTime.MinValue;
    
            return _dob;
        }
        set
        {
            if (value < SqlDateTime.MinValue)
                _dob = (DateTime)SqlDateTime.MinValue;
            else
                _dob = (DateTime)value;
        }
    }
    
    // Field use in your code
    public DateTime dob
    {
        get { return _dob; }
        set
        {
            if (value < SqlDateTime.MinValue)
                _dob = (DateTime)SqlDateTime.MinValue;
            else
                _dob = value;
        }
    }
