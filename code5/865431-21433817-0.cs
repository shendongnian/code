    public static IDictionary<string, Meter> LoadMeterListFromFile()
    {
        var meters = new List<Meter>();
    
        // ...
        // current implementation
    
        return meters.ToDictionary(meter => meter.MeterUID);
    }
