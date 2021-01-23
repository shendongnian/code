    interface Device<T> where T:DeviceSettings
    {
    T GetDevice();
    void SerDevice(T settings);
    }
    
    class DeviceA:Device<DeviceASettings>
    {
        public DeviceASettings GetDevice()
        {
            throw new NotImplementedException();
        }
        public void SerDevice(DeviceASettings settings)
        {
            throw new NotImplementedException();
        }
    }
