    VideoCaptureDevice frontDevice = null;
    ReadOnlyCollection<VideoCaptureDevice> devices = CaptureDeviceConfiguration.GetAvailableVideoCaptureDevices();
    foreach (VideoCaptureDevice dev in devices)
    {
        if (!dev.IsDefaultDevice)
        {
            device = dev;
        }
    }
    // for now device contains front-face camera
