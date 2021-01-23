    Db.Insert(new DeviceInfo.DeviceInfo 
       { DeviceType = NewDevice.Type, HumanReadDevId = 
         NewDevice.HumanReadableDeviceSN, 
         Hardware = NewDevice.Hardware, Model = NewDevice.Model });
    var newNewDeviceId = Db.GetLastInsertId();
    Db.Insert(new DeviceHistory.DeviceHistory { Firmware = NewDevice.Firmware, 
               SWVer1 = NewDevice.SwVer1, SWVer2 = NewDevice.SwVer2 });
    var newNewDeviceHistoryId = Db.GetLastInsertId();
    // Then in any kind of select use the var not the function
    var deviceInfo = Db.SingleById<DeviceInfo.DeviceInfo>(newNewDeviceId);
