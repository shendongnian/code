    var result = machines.SelectMany(x => x.Devices, 
                                        (machineObj, devices) => new { machineObj, devices })
                         .GroupBy(x => new { x.devices.DeviceType, x.machineObj.Department, 
                                                                 x.machineObj.LocationName })
                         .Select(x => new
                                     {
                                         DeviceType = x.Key.DeviceType,
                                         Department = x.Key.Department,
                                         Location = x.Key.LocationName,
                                         machines = x
                                     });
