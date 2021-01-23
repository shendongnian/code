    clientes = cursor.Select(c => new Client()
    {
         ClientId = c.ClientId,
         devices = c.Devices.Select(d => new Client.Device()
         {
             DeviceId = d.DeviceId,
             DeviceType = d.DeviceType
         }).ToList()
     }).ToList()
