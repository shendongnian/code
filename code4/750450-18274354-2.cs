    // Add the following properties to the USBDevice class
    // Leave everything else as is
    public byte DeviceClass
    {
       get { return DeviceDescriptor.bDeviceClass; }
    }
    public byte DeviceSubClass
    {
       get { return DeviceDescriptor.bDeviceSubClass; }
    }
    public byte DeviceProtocol
    {
       get { return DeviceDescriptor.bDeviceProtocol; }
    }
