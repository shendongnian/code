    private static IQueryable<Device> FilterDeviceList(List<Device> devices, Device device)
    {
        var query = devices.AsQueryable();
    
        if (device.Name != null)
            query = query.Where(d => d.Name == device.Name);
    
        if (device.OS != null)
            query = query.Where(d => d.OS == device.OS);
    
        if (device.Status != null)
            query = query.Where(d => d.Status == device.Status);
    
        if (device.LastLoggedInUser != null)
            query = query.Where(d => d.LastLoggedInUser == device.LastLoggedInUser);
        return query;
    }
