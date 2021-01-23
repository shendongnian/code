    [ComImport]
    [Guid("641BD880-2DC8-11D0-90EA-00AA0060F86C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStillImage
    {
        int Initialize();
        int GetDeviceList();
        int GetDeviceInfo();
        int CreateDevice();
        int GetDeviceValue();
        int SetDeviceValue();
        int GetSTILaunchInformation();
        [PreserveSig]
        int RegisterLaunchApplication([In, MarshalAs(UnmanagedType.LPWStr)] string pwszAppName, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommandLine);
        [PreserveSig]
        int UnregisterLaunchApplication([In, MarshalAs(UnmanagedType.LPWStr)] string pwszAppName);
    }
