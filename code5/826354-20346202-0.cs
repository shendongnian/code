    public IDevice
    {
        IDeviceConnection Connect(int timeout);
    }
    
    public IDeviceConnection: IDispose //Dispose() disconnects your device. Enables using() statements
    {
        int WriteData();
        byte[] ReceiveData();
    }
