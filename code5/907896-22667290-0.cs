    public Location DevPosition { get; set; }
    public double nDeviceLon
    {
        get
        {
            if (nDevicePosition.IsUnknown)
                return nDefaultLongitude;
            else
                return nDevicePosition.Longitude; }
        set 
	{ 
		nDevicePosition.Longitude = value; 
		DevPosition = new Location(nDeviceLat, nDeviceLon);
	}
    }
    public double nDeviceLat
    {
        get
        {
            if (nDevicePosition.IsUnknown)
                return nDefaultLatitude;
            else
                return nDevicePosition.Latitude;
        }
        set { 
		nDevicePosition.Latitude = value; 
		DevPosition = new Location(nDeviceLat, nDeviceLon);
	}
    }
