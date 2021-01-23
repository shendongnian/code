    private static IQueryable<Device> FilterDeviceList(List<Device> devices, Device device)
    {
        var query = devices.AsQueryable();
    
        if (device.Name != null)
            query = query.Where(d => d.Name == device.Name);
    
        if (device.OS != null)
            query = query.Where(d => d.OS == device.OS);
    
        // ...
    
        return query;
    }
