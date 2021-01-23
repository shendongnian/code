    public IEnumerable<Device> FilterDevices(IEnumerable<Device> devices, IEnumerable<Func<Device, string>> filters, string filterValue)
    {
        foreach (var filter in filters)
        {
            devices = devices.Where(d => filter(d).Equals(filterValue));
        }
    
        return devices;
    }
