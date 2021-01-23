    public async static Task<GattCommunicationStatus> WriteByte(string paramDeviceID, Guid paramService, byte paramValue)
    {
        string debug;
        var Services = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid([UUID HERE]), null);
        GattDeviceService Service = await GattDeviceService.FromIdAsync(paramDeviceID);
        debug = "Using service: " + Services[0].Name; // Service name is correct
        GattCharacteristic gattCharacteristic = Service.GetCharacteristics(paramService)[0];
        var writer = new Windows.Storage.Streams.DataWriter();
        writer.WriteByte(paramValue);
        try{
            return GattCommunicationStatus status = await gattCharacteristic.WriteValueAsync(writer.DetachBuffer()); 
        }
        catch()
        {
            debug = "Write failed";
            return GattCommunicationStatus.Unreachable;
        }
    }
