    internal abstract class Device // Generic name here as I don't know what kind of device you are talking to {
        // Common code here
        // abstract and/or virtual members here for the different behaviours in the various firmware versions        
    }
    internal sealed class DeviceFirmwareA : Device
    {
         // Private, firmware-specific enumerations here
         // Overrides here
    }
    internal sealed class DeviceFirmwareB : Device
    {
         // Private, firmware-specific enumerations here
         // Overrides here
    }
