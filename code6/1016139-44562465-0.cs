	var propertiesToQuery = new List<string>() { 
	    "System.ItemNameDisplay",
        "System.Devices.DeviceInstanceId",
        "System.Devices.Parent",
        "System.Devices.LocationPaths",
        "System.Devices.Children"
	};
	
	var id1 = @"USB\VID_E4F1&PID_0661\00000115FA9CE7750000000000000000";
	
	var device1 = await PnpObject.FindAllAsync(PnpObjectType.Device, 
												propertiesToQuery, 
												"System.Devices.DeviceInstanceId:=\"" + id1 + "\"");
	var id2 = @"USB\VID_E4F1&PID_0661&MI_00\7&B5A5DDF&0&0000";
	
	var device2 = await PnpObject.FindAllAsync(PnpObjectType.Device, 
												propertiesToQuery, 
												"System.Devices.DeviceInstanceId:=\"" + id2 + "\"");
	var parent1 = device1.Properties["System.Devices.Parent"] as string;
	var parent2 = device2.Properties["System.Devices.Parent"] as string;
	
	if (parent1 && parent1 == id2)
	{
		WriteLine("Device 2 is parent of device 1");
	}
	
	if (parent2 && parent2 == id1)
	{
		WriteLine("Device 11 is parent of device 2");
	}
												
	var child_ids = device1.Properties["System.Devices.Children"] as string[];
	
	if (child_ids != null){
		foreach (var id in child_ids)
		{
			if (id == id2){
				WriteLine("Device 2 is child of device 1")
			}
		}
	}
	
	 child_ids = device2.Properties["System.Devices.Children"] as string[];
	
	if (child_ids != null){
		foreach (var id in child_ids)
		{
			if (id == id1){
				WriteLine("Device 1 is child of device 2")
			}
		}
	}
