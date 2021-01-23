    private double _longitude;
    public double Longitude
    {
        get
        {
            return _longitude;
        }
        set
        {
            if(value < -180 || value > 180)
            {
                throw new ArgumentException("value");
            }
            _longitude = value;
        }
    }
