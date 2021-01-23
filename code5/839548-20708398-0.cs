    public int DriverTypeId { get; set; }
    public DriverType IntAsEnum // proxy property, doesn't store any value, only does the conversion
    {
        get { return (DriverType)DriverTypeId; }
        set { DriverTypeId = (int)value; }
    }
