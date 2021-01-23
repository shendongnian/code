    [SetUp]
    public void SetupDeviceController()
    {
        dev = new TestDevice();
        dc = new DeviceController(dev);
        dc.Open();
        dev.Read += dev_Read;
    }
