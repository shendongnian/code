    class DeviceClassKey : IEquatable<DeviceClassKey> {
    
     //Data members here
     int DeviceClassID; /* just an example */
    
     public static DeviceClassKey FromDeviceClass(DeviceClass dc) { return ...; }
     public static DeviceClassKey FromActualDevice(ActualDevice ad) { return ...; }
    
     //add equality members here
    }
