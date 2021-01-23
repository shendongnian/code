    // I want you to pass me a pluggable device, I don't care if it's a Joystick or a Mouse
    public static void DoWork(IPluggable pluggableDevice)
    {
        try
        {
            // something will go wrong !
        }
        catch (Exception ex)
        {
            LogException(ex);
            // all pluggable devices can disconnect, I don't care what you've passed as an argument!
            pluggableDevice.Disconnect();
        }
    }
