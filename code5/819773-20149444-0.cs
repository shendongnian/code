    sealed class MyClass 
    {
        public MyClass(string device, string deviceTypeId, int deviceTypeCode, bool someBool)
        {
            this.Device = device;
            this.DeviceTypeId = deviceTypeId;
            this.DeviceTypeCode = deviceTypeCode;
            this.SomeBool = someBool
        }
        string Device { get; private set; }
        string DeviceTypeId { get; private set; }
        int DeviceTypeCode { get; private set; }
        bool SomeBool { get; private set; }
    }
