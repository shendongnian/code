    [SetUp]
    public void SetupDeviceController()
    {
        dev = new TestDevice();
        dc = new DeviceController(dev);
        dev.Read += dev_Read;
        dc.Open();
    }
