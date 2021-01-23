    public void DoOperationOnDevice(Device d)
    {
        d.SomeDeviceOperation();
    }
    Device d = new Joystick();
    d.SomeDeviceOperation();
    DoOperationOnDevice(new Keyboard());
    d = new Mouse();
