    public ActionResult DeviceName(string name)
    {
        SampleEntities sampleEntities = new SampleEntities();
        try
        {
            var model = (from dev in sampleEntities.NetworkDevices
                         where dev.Name == name
                         from inter in sampleEntities.DeviceInterfaces
                         where inter.NetworkDevice.Id == dev.Id
                         select new DeviceInterfaceModel
                         { 
                             DeviceName = dev.Name, 
                             InterfaceName = inter.Name,
                             IPv4Address = inter.IPv4Address,
                             IPv4SubnetMask = inter.IPv4SubnetMask,
                             CIDR = inter.CIDR,
                             Subnet = inter.Subnet
                         }).ToList();
            return View(model);
        }
        catch
        {
        }
        return View();
    }
