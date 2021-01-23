        int userId = -1;
        List<Device> myDevices;
        if (Int32.TryParse(User.Identity.Name, out userId))
        {
            myDevices = db.Devices.Where((x => x.EndUserId == userId && x.Deleted == false)).OrderByDescending(x => x.LastComms).ToList();
            var result1 = myDevices.Where(x=>x.name==someName);
            var result2 = myDevices.Where(x=>x.deviceId >someDeviceId );
            var result3 = myDevices.Where(x=>x.serialNo.Contains("someSerialNo"));
            ....
            return resultN.ToList();
        }
