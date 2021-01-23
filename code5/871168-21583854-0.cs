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
                throw new ArgumentException("Invalid latitude");
            }
            mLatitude = value;
        }
    }
    private double mLatitude;
