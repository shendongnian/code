    [ConfigurationProperty("spatialSRID", DefaultValue = 4326)]
    public int SpatialSRID
    {
        get { return (int)this["spatialSRID"]; }
        set { this["spatialSRID"] = value; }
    }
