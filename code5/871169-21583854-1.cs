    public double Latitude
    {
        get
        {
            return mLatitude;
        }
        set
        {
            if (value > 90 || value < -90)
            {
                throw new ArgumentOutOfRangeException("Invalid latitude");
            }
            mLatitude = value;
        }
    }
    private double mLatitude;
