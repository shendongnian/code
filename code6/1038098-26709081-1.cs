    foreach(var table in arptable)
    {
        var device = DeviceTable.SingleOrDefault(...);
        if (device != null)
        {
            table.Description = device.Model ?? device.DeviceName;
        }
    }
